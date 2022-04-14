// Decompiled with JetBrains decompiler
// Type: RISHI_HHT_APP.Droid.Sounds.Sounds
// Assembly: RISHI_HHT_APP.Android, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B790BEE4-67B8-4A5A-BD9D-D0FA99DC5ADC
// Assembly location: C:\Users\sar.puttaraju.ah\Desktop\RISHI_HHT_APP.Android.dll

using Android.App;
using Android.Media;
using Android.OS;
using RISHI_HHT_APP.CommonClass;

[assembly: Xamarin.Forms.Dependency(typeof(RISHI_HHT_APP.Droid.Sounds.Sounds))]
namespace RISHI_HHT_APP.Droid.Sounds
{
    internal class Sounds : SoundPlay
    {
        private MediaPlayer _mediaPlayer;

        public void PlaySound(string MsgType)
        {
            if (MsgType == "Error")
            {
                this._mediaPlayer = MediaPlayer.Create(Android.App.Application.Context, 2130837597);
                this._mediaPlayer.Looping = true;
                this._mediaPlayer.Start();
                Vibrator vibrator = Vibrator.FromContext(Android.App.Application.Context);
                if (vibrator.HasVibrator)
                    vibrator.Vibrate(50000L);
            }
            if (!(MsgType == "Success"))
                return;
            MediaPlayer.Create(Application.Context, 2130837815).Start();
            Vibrator vibrator1 = Vibrator.FromContext(Application.Context);
            if (vibrator1.HasVibrator)
                vibrator1.Vibrate(1000L);
        }

        public void StopSound()
        {
            Vibrator.FromContext(Application.Context).Cancel();
            if (this._mediaPlayer == null)
                return;
            this._mediaPlayer.Stop();
        }
    }
}
