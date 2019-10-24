using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Newtonsoft.Json;
using System.Net;
using Plugin.LocalNotifications;

namespace PengingatShalatApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            string waktuisya, waktumaghrib, waktuashar, waktudzuhur, waktusubuh, waktudhuha;
            string tanggalnow = DateTime.Now.ToString("yyyy-MM-dd");
            //string waktunow = DateTime.Now.ToString("HH:mm");

            string path = "https://api.banghasan.com/sholat/format/json/jadwal/kota/682/tanggal/" + tanggalnow;
            var json = new WebClient().DownloadString(path);
            RootObject _shalat = JsonConvert.DeserializeObject<RootObject>(json);

            lblSubuh.Text = "Waktu Subuh = " + _shalat.jadwal.data.subuh;
            lblDzuhur.Text = "Waktu Dzuhur = " + _shalat.jadwal.data.dzuhur;
            lblAshar.Text = "Waktu Ashar = " + _shalat.jadwal.data.ashar;
            lblMaghrib.Text = "Waktu Maghrib = " + _shalat.jadwal.data.maghrib;
            lblIsya.Text = "Waktu Isya = " + _shalat.jadwal.data.isya;

            waktusubuh = _shalat.jadwal.data.subuh + ":00";
            waktudzuhur = _shalat.jadwal.data.dzuhur + ":00";
            waktuashar = _shalat.jadwal.data.ashar + ":00";
            waktumaghrib = _shalat.jadwal.data.maghrib + ":00";
            waktuisya = _shalat.jadwal.data.isya + ":00";
            waktudhuha = _shalat.jadwal.data.dhuha + ":00";

            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                Device.BeginInvokeOnMainThread(() => lblWaktu.Text = "Waktu Saat Ini Detik : " + DateTime.Now.ToString("HH:mm:ss"));
                Device.BeginInvokeOnMainThread(() => lblwaktu2.Text = DateTime.Now.ToString("HH:mm:ss"));
                //Device.BeginInvokeOnMainThread(() => times = DateTime.Now.ToString("HH:mm"));
                if(lblwaktu2.Text == waktuisya)
                {
                    CrossLocalNotifications.Current.Show("Hi Manusia", "Yuk Kita Solat Isya!");
                    Play();
                }
                else if (lblwaktu2.Text == waktumaghrib)
                {
                    CrossLocalNotifications.Current.Show("Hi Manusia", "Yuk Kita Solat Maghrib!");
                    Play();
                }
                else if (lblwaktu2.Text == waktuashar)
                {
                    CrossLocalNotifications.Current.Show("Hi Manusia", "Yuk Kita Solat Ashar!");
                    Play();
                }
                else if (lblwaktu2.Text == waktudzuhur)
                {
                    CrossLocalNotifications.Current.Show("Hi Manusia", "Yuk Kita Solat Dzuhur!");
                    Play();
                }
                else if (lblwaktu2.Text == waktusubuh)
                {
                    CrossLocalNotifications.Current.Show("Hi Manusia", "Yuk Kita Solat Subuh!");
                    Play();
                }
                else if (lblwaktu2.Text == waktudhuha)
                {
                    CrossLocalNotifications.Current.Show("Hi Manusia", "Yuk Kita Solat Dhuha!");
                    Play();
                }
                else if (lblwaktu2.Text == "18:35:00")
                {
                    CrossLocalNotifications.Current.Show("Hi Manusia", "Test 1!");
                    Play();
                }
                else if (lblwaktu2.Text == "20:25:00")
                {
                    CrossLocalNotifications.Current.Show("Hi Manusia", "Test 2!");
                    Play();
                }
                return true;
            });
        }
        private void Play()
        {
            var assembly = typeof(App).GetTypeInfo().Assembly;
            Stream audioStream = assembly.GetManifestResourceStream("PengingatShalatApp.Resources.adzan.wav");
            var audio = Plugin.SimpleAudioPlayer.CrossSimpleAudioPlayer.Current;
            audio.Load(audioStream);

            audio.Play();
        }
    }

    public class Query
    {
        public string format { get; set; }
        public string kota { get; set; }
        public string tanggal { get; set; }
    }

    public class Data
    {
        public string ashar { get; set; }
        public string dhuha { get; set; }
        public string dzuhur { get; set; }
        public string imsak { get; set; }
        public string isya { get; set; }
        public string maghrib { get; set; }
        public string subuh { get; set; }
        public string tanggal { get; set; }
        public string terbit { get; set; }
    }

    public class Jadwal
    {
        public string status { get; set; }
        public Data data { get; set; }
    }

    public class RootObject
    {
        public string status { get; set; }
        public Query query { get; set; }
        public Jadwal jadwal { get; set; }
    }
}
