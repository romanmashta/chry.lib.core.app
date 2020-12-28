using System.Collections.Generic;

namespace Cherry.Lib.Core.App.Bot
{
    public class StickerSet
    {
        public string Name { get; set; }
        public List<Sticker> Stickers { get; set; } = new List<Sticker>();
    }

    public class Sticker
    {
        public string Name { get; set; }
        public string ThumbId { get; set; }
        public string Id { get; set; }
        public bool IsAnimated { get; set; }
    }
}