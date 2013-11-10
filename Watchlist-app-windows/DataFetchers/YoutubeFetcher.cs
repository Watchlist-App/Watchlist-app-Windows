using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Net;
using System.IO;


namespace Watchlist_app_windows.DataFetchers
{
    class YoutubeFetcher
    {
        public string ExecuteYoutubeFetch(string user_string)
        {
            int sym;
            char[] mas = new char[2048];

            string key = "&key=AIzaSyAZ-O1FHzD0qOn0zeLmVGTJhBybVp4yXUA";
            string type = "&type=movie";
            string str = "https://www.googleapis.com/youtube/v3/search?part=snippet&q=" + user_string + key + type;

            WebRequest req = WebRequest.Create(str);
            WebResponse resp = req.GetResponse();
            Stream istr = resp.GetResponseStream();

            try
            {
                for (int i = 1; ; i++)
                {
                    sym = istr.ReadByte();
                    if (sym == -1) break;
                    if (i < 2047) mas[i] = (char)sym;                   
                    if ((i % 400) == 0)
                    {
                       // Console.Write("\nPress Enter.");
                       // Console.ReadLine();
                    }
                }
            }
            catch (WebException Exc)
            { Console.WriteLine("Сетевая ошибка: " + Exc.Message + "\nКод состояния: " + Exc.Status); }
            catch (ProtocolViolationException Exc)
            { Console.WriteLine("Протокольная ошибка: " + Exc.Message); }
            catch (UriFormatException Exc)
            { Console.WriteLine("Ошибка формата URI: " + Exc.Message); }
            catch (NotSupportedException Exc)
            { Console.WriteLine("Неизвестный протокол: " + Exc.Message); }
            catch (IOException Exc)
            { Console.WriteLine("Ошибка ввода/вывода: " + Exc.Message); }
            catch (System.Security.SecurityException Exc)
            { Console.WriteLine("Исключение в связи с нарушением безопасности" + Exc.Message); }
            catch (InvalidOperationException Exc)
            { Console.WriteLine("Недопустимая операция: " + Exc.Message); }
           // Console.ReadKey();
            resp.Close();
            string resp_string = new string(mas);
            return resp_string;
        }
        static string videoIDForTitle(string response_string)
        {
            char[] masvideoId = new char[12];
            int index = response_string.IndexOf("videoId\": \"", StringComparison.Ordinal);
            index += 11;
           // Console.WriteLine(index);
            for (int i = index, j = 0; i < index + 11; i++, j++)
                masvideoId[j] = response_string[i];
            string videoId = new string(masvideoId);
            return videoId;
        }
        static string videoURLForTitle(string response_string)
        {
            char[] masvideoURL = new char[64];
            int index = response_string.IndexOf("url\": \"", StringComparison.Ordinal);
            index += 7;
            for (int k = index, j = 0; response_string[k] != '"'; k++, j++)
                masvideoURL[j] = response_string[k];
            string videoURL = new string(masvideoURL);
            return videoURL;
        }
    }
}
