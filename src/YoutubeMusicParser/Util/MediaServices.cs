using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YoutubeMusicParser.Util {
    class MediaServices {
        // Add the prefixs here to be removed
        // That simple
        public static string[]
            Services = {
                "- YouTube"
            };

        public static void StripWebBrowsers(string @in, out string @out) {
            @out = @in;
            
            var temp = @in.Split('-');
            var removeStr = temp[temp.Length - 1];

            @out = @out.Replace("-"  + removeStr,    "");
            @out = @out.Replace("- " + removeStr,   "");
        }

        public static void StripWebPlayers(string @in, out string @out) {
            // Spotify, Soundcloud ect...
            @out = @in;

            foreach (string str in Services)
                @out = @out.Replace(str, "");
        }

        public static string GetSongTitleFromText(string str) {
            // Remove the web browsers from the text
            StripWebBrowsers(str, out str);

            // Remove youtube's logo
            StripWebPlayers(str, out str);
            
            // Return our video title
            return str.Trim();
        }

        public static string GetVideoFromProc(ProcessListing pl) {
            var str = pl.WindowText;
            return GetSongTitleFromText(str);
        }

        public static bool isPlayingAMediaService(string str) {
            bool flag = false;
            foreach (string st in Services) if(str.Contains(st)) flag = true;
            return flag;
        }
    }
}
