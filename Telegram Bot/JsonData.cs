using System.Collections.Generic;

namespace Telegram_Bot
{
    #region inline keyborad
    public class Inline_keyboardItemItem
    {
        public string text { get; set; }
        public string callback_data { get; set; }
    }
    public class Inline_keyboard
    {
        public List<List<Inline_keyboardItemItem>> inline_keyboard { get; set; }
    }

    namespace InlineKeyBoradUrl 
    {
        public class Inline_keyboardItemItem
        {
            public string text { get; set; }
            public string url { get; set; }
        }
        public class Inline_keyboard
        {
            public List<List<Inline_keyboardItemItem>> inline_keyboard { get; set; }
        }
    }

    #endregion

    #region miankeyBord
    public class KeyboardItemItem
    {
        public string text { get; set; }
    }

    public class keyBord
    {
        public List<List<KeyboardItemItem>> keyboard { get; set; }
        public bool one_time_keyboard { get; set; }
        public bool resize_keyboard { get; set; }
    }
    #endregion

    #region File Info Upload File
    enum TypeMessage : byte
    {
        photo, voice,
        document, animation,
        sticker, audio
    }
    class FileUploadInfo
    {
        public string Token { get; set; }
        public string PathFile { set; get; }
        public int Chat_Id { set; get; }
    }
    #endregion

    #region File Info Get
    public class Result_Bot
    {
        public string file_id { get; set; }
        public string file_unique_id { get; set; }
        public int file_size { get; set; }
        public string file_path { get; set; }
    }
    public class File_Bot
    {
        public bool ok { get; set; }
        public Result_Bot result { get; set; }
    }
    #endregion

    #region Get Update Message


    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Animation
    {
        public string mime_type { get; set; }
        public int duration { get; set; }
        public int width { get; set; }
        public int height { get; set; }
        public Thumb thumb { get; set; }
        public string file_id { get; set; }
        public string file_unique_id { get; set; }
        public int file_size { get; set; }
    }

    public class Audio
    {
        public int duration { get; set; }
        public string file_name { get; set; }
        public string mime_type { get; set; }
        public string title { get; set; }
        public string performer { get; set; }
        public string file_id { get; set; }
        public string file_unique_id { get; set; }
        public int file_size { get; set; }
    }

    public class CallbackQuery
    {
        public string id { get; set; }
        public From from { get; set; }
        public Message message { get; set; }
        public string chat_instance { get; set; }
        public string data { get; set; }
    }

    public class Chat
    {
        public int id { get; set; }
        public string first_name { get; set; }
        public string username { get; set; }
        public string type { get; set; }
    }

    public class Contact
    {
        public string phone_number { get; set; }
        public string first_name { get; set; }
        public string vcard { get; set; }
    }

    public class Document
    {
        public string mime_type { get; set; }
        public Thumb thumb { get; set; }
        public string file_id { get; set; }
        public string file_unique_id { get; set; }
        public int file_size { get; set; }
        public string file_name { get; set; }
    }

    public class From
    {
        public decimal id { get; set; }
        public bool is_bot { get; set; }
        public string first_name { get; set; }
        public string username { get; set; }
        public string language_code { get; set; }
    }

    public class Location
    {
        public double latitude { get; set; }
        public double longitude { get; set; }
    }

    public class Message
    {
        public int message_id { get; set; }
        public From from { get; set; }
        public Chat chat { get; set; }
        public int date { get; set; }
        public string text { get; set; }
        public ReplyMarkup reply_markup { get; set; }
        public Animation animation { get; set; }
        public Document document { get; set; }
        public Sticker sticker { get; set; }
        public Voice voice { get; set; }
        public List<Photo> photo { get; set; }
        public Contact contact { get; set; }
        public Location location { get; set; }
        public Audio audio { get; set; }
    }

    public class Photo
    {
        public string file_id { get; set; }
        public string file_unique_id { get; set; }
        public int file_size { get; set; }
        public int width { get; set; }
        public int height { get; set; }
    }

    public class ReplyMarkup
    {
        public List<List<Inline_keyboardItemItem>> inline_keyboard { get; set; }
    }

    public class Result
    {
        public int update_id { get; set; }
        public CallbackQuery callback_query { get; set; }
        public Message message { get; set; }
    }

    public class Messase_Bot
    {
        public bool ok { get; set; }
        public List<Result> result { get; set; }
    }

    public class Sticker
    {
        public int width { get; set; }
        public int height { get; set; }
        public string emoji { get; set; }
        public string set_name { get; set; }
        public bool is_animated { get; set; }
        public bool is_video { get; set; }
        public Thumb thumb { get; set; }
        public string file_id { get; set; }
        public string file_unique_id { get; set; }
        public int file_size { get; set; }
    }

    public class Thumb
    {
        public string file_id { get; set; }
        public string file_unique_id { get; set; }
        public int file_size { get; set; }
        public int width { get; set; }
        public int height { get; set; }
    }

    public class Voice
    {
        public int duration { get; set; }
        public string mime_type { get; set; }
        public string file_id { get; set; }
        public string file_unique_id { get; set; }
        public int file_size { get; set; }
    }





    #endregion
}
