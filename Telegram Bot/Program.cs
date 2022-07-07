using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using static System.Console;

namespace Telegram_Bot
{
    class Program
    {
        static WebClient Client = new WebClient();
        static string Token = "5244510127:AAGlfa79LXntpQfrPk3_lxQUj8syi1xefy0";
        public static void Main(string[] args)
        {
            long ofset = 0;
            string url = $"https://api.telegram.org/bot{Token}/";

            while (true)
            {
                try
                {
                    var response = JsonConvert.DeserializeObject<Messase_Bot>(Client.DownloadString(url + $"getUpdates?offset={ofset}"));
                    foreach (var item in response.result)
                    {
                        WriteLine("Message Update : " + item.update_id);

                        if (item.callback_query != null)
                        {
                            Client.DownloadString($"{url}sendMessage?chat_id={item.callback_query.message.chat.id}&text=Hello");
                        }
                        else if (item.message.text == "/start")
                        {
                            _ = Client.DownloadString($"{url}sendMessage?chat_id={item.message.chat.id}&text={item.message.text}");
                        }
                        else if (item.message.text == "key")
                        {
                            //var ananimousClass = new { inline_keyboard = new Dictionary<string, string>() { "hi" } };
                            //string json = "{\"inline_keyboard\": [[{\"text\": \"hi\",\"callback_data\": \"hi\"} , {\"text\": \"hi\",\"callback_data\": \"hi\"}] , [{\"text\": \"hi2\",\"callback_data\": \"hi2\"}]]}";
                            var a = new Inline_keyboard();
                            a.inline_keyboard = new List<List<Inline_keyboardItemItem>>();
                            a.inline_keyboard.Add(new List<Inline_keyboardItemItem>
                            {
                                new Inline_keyboardItemItem(){text = "Hello" , callback_data = "htt"} ,
                                new Inline_keyboardItemItem(){text = "Hi" , callback_data = "key2"} ,
                                new Inline_keyboardItemItem(){text = "ok" , callback_data = "key3"}
                            });
                            a.inline_keyboard.Add(new List<Inline_keyboardItemItem>
                            {
                                new Inline_keyboardItemItem(){text = "Hello" , callback_data = "key1"}
                            });
                            string jesonV = JsonConvert.SerializeObject(a);
                            Client.DownloadString($"{url}sendMessage?chat_id={item.message.chat.id}&text={item.message.text}&reply_markup={jesonV}");
                        }
                        else if (item.message.text == "key3") 
                        {
                            var a = new InlineKeyBoradUrl.Inline_keyboard();
                            a.inline_keyboard = new List<List<InlineKeyBoradUrl.Inline_keyboardItemItem>>();
                            a.inline_keyboard.Add(new List<InlineKeyBoradUrl.Inline_keyboardItemItem>() 
                            {
                                new InlineKeyBoradUrl.Inline_keyboardItemItem(){text = "Hello" ,url = "http://google.com" }
                            });
                            Client.DownloadString($"{url}sendMessage?chat_id={item.message.chat.id}&text={item.message.text}&reply_markup={JsonConvert.SerializeObject(a)}");
                        }
                        else if(item.message.text == "key2") 
                        {
                            var a = new keyBord();
                            a.keyboard = new List<List<KeyboardItemItem>>();
                            a.keyboard.Add(new List<KeyboardItemItem> 
                            {
                                new KeyboardItemItem(){text = "ky1"} , new KeyboardItemItem(){text = "key2"}
                            });
                            a.keyboard.Add(new List<KeyboardItemItem>
                            {
                                new KeyboardItemItem(){text = "ky1"}
                            });
                            a.one_time_keyboard = true;
                            a.resize_keyboard = true;
                            Client.DownloadString($"{url}sendMessage?chat_id={item.message.chat.id}&text={item.message.text}&reply_markup={JsonConvert.SerializeObject(a)}");
                        }
                        else if (item.message.photo != null)
                        {
                            for (int i = 0; i < item.message.photo.Count; i++)
                            {
                                var File = JsonConvert.DeserializeObject<File_Bot>(Client.DownloadString($"https://api.telegram.org/bot{Token}/getFile?file_id={item.message.photo[i].file_id}"));
                                Client.DownloadFile($"https://api.telegram.org/file/bot{Token}/{File.result.file_path}", $"d:\\DirPhoto\\{Path.GetFileName(i + File.result.file_path)}");
                            }
                        }
                        else if (item.message.document != null)
                        {
                            var File = JsonConvert.DeserializeObject<File_Bot>(Client.DownloadString($"https://api.telegram.org/bot{Token}/getFile?file_id={item.message.document.file_id}"));
                            Client.DownloadFile($"https://api.telegram.org/file/bot{Token}/{File.result.file_path}", $"d:\\DirPhoto\\{Path.GetFileName(File.result.file_path)}");
                        }
                        else if (item.message.voice != null)
                        {
                            var File = JsonConvert.DeserializeObject<File_Bot>(Client.DownloadString($"https://api.telegram.org/bot{Token}/getFile?file_id={item.message.voice.file_id}"));
                            Client.DownloadFile($"https://api.telegram.org/file/bot{Token}/{File.result.file_path}", $"d:\\DirPhoto\\{Path.GetFileName(File.result.file_path)}");
                        }
                        else if (item.message.sticker != null)
                        {
                            WriteLine(Upload(new FileUploadInfo
                            {
                                Token = Token,
                                Chat_Id = item.message.chat.id,
                                PathFile = @"C:\Users\SZA\Desktop\Untitled-1.jpg"
                            }, TypeMessage.sticker));
                        }
                        else if (item.message.contact != null)
                        {
                            _ = Client.DownloadString($"{url}sendContact?chat_id={item.message.chat.id}&phone_number=12345&first_name=reza");
                        }
                        else if (item.message.text == "photo")
                        {
                            //_ = Client.DownloadString($"https://api.telegram.org/bot{Token}/sendSticker?chat_id={item.message.chat.id}&sticker=CAADAgADOQADfyesDlKEqOOd72VKAg");

                            WriteLine(Upload(new FileUploadInfo
                            {
                                Token = Token,
                                Chat_Id = item.message.chat.id,
                                PathFile = @"C:\Users\SZA\Desktop\Untitled-1.jpg"
                            }, TypeMessage.photo));
                        }
                        else 
                        {
                            Client.DownloadString($"{url}sendMessage?chat_id={item.message.chat.id}&text={item.message.text}");
                        }
                        ofset = item.update_id + 1;
                        WriteLine("----------------");
                    }
                    System.Threading.Thread.Sleep(10);
                }
                catch (System.Exception ex)
                {
                    WriteLine(ex.Message);
                }
            }
        }

        public static string Upload(FileUploadInfo fileInfo, TypeMessage type)
        {
            string url = $"https://api.telegram.org/bot{fileInfo.Token}/send{type}?chat_id={fileInfo.Chat_Id}";
            using (var client = new HttpClient())
            {
                using (var content = new MultipartFormDataContent())
                {
                    content.Add(new StreamContent(new MemoryStream(File.ReadAllBytes(fileInfo.PathFile))), type.ToString(), Path.GetFileName(fileInfo.PathFile));
                    using (var message = client.PostAsync(url, content).Result)
                    {
                        return message.Content.ReadAsStringAsync().Result;
                    }
                }
            }
        }
    }
}