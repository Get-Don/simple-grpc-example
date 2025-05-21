using Chat;
using Grpc.Core;
using System.Windows.Forms;
using System.Xml.Linq;

namespace ChatClient
{
    public partial class Form1 : Form
    {
        private const string _serverAddr = "127.0.0.1:3000";
        private Channel _channel;
        private ChatService.ChatServiceClient _client;
        private CancellationTokenSource _cts;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbxName.Text)) return;
                        
            _channel = new Channel(_serverAddr, ChannelCredentials.Insecure);
            _client = new ChatService.ChatServiceClient(_channel);
            _cts = new CancellationTokenSource();

            var receiveTask = Task.Run(async () =>
            {
                try
                {
                    using var response = _client.StreamingMessage(new ConnectRequest
                    {
                        Name = tbxName.Text
                    });

                    Invoke(() => StartChat());

                    await foreach (var message in response.ResponseStream.ReadAllAsync(_cts.Token))
                    {
                        lbxChatLog.Invoke(new Action(() =>
                        {
                            lbxChatLog.Items.Add($"{message.Name}: {message.Message}");                            
                            lbxChatLog.SelectedIndex = lbxChatLog.Items.Count - 1;
                            lbxChatLog.ClearSelected();
                        }));
                    }
                }
                catch (RpcException ex) when (ex.StatusCode == StatusCode.Cancelled)
                {
                    // 정상적인 연결 종료                    
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    lbxChatLog.Invoke(new Action(() =>
                    {
                        lbxChatLog.Items.Add($"[System] Error: {ex.Message}");
                    }));
                }
                finally
                {
                    Invoke(() => EndChat());
                }
            });
        }

        private async void btnDisconnect_Click(object sender, EventArgs e)
        {
            _cts.Cancel();
            await _channel.ShutdownAsync();
        }

        private async void btnSend_Click(object sender, EventArgs e)
        {
            await SendMessage();
        }

        private async void tbxMessage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;

            await SendMessage();
        }
        private async Task SendMessage()
        {
            if (string.IsNullOrEmpty(tbxMessage.Text)) return;

            try
            {
                var request = new ChatMessage { Name = tbxName.Text, Message = tbxMessage.Text };
                await _client.PostMessageAsync(request);
            }
            catch (Exception ex)
            {
                lbxChatLog.Items.Add($"[System] Error: {ex.Message}");
            }

            tbxMessage.Text = "";
        }

        private void StartChat()
        {
            btnDisconnect.Enabled = true;
            btnSend.Enabled = true;
            tbxMessage.Enabled = true;

            btnConnect.Enabled = false;
            tbxName.Enabled = false;

            lbxChatLog.Items.Add("[System] Start Chat!");
        }

        private void EndChat()
        {
            btnDisconnect.Enabled = false;
            btnSend.Enabled = false;
            tbxMessage.Enabled = false;

            btnConnect.Enabled = true;
            tbxName.Enabled = true;

            lbxChatLog.Items.Add("[System] End Chat!");
        }
    }
}
