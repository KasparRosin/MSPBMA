using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android.Content;

namespace AndroidApp_Test_
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            int count = 0;
            
            var TextView = FindViewById<TextView>(Resource.Id.textView1);
            var button = FindViewById<Button>(Resource.Id.button1);
            var Second_Activity_Button = FindViewById<Button>(Resource.Id.button2);
            var Third_Activity_Button = FindViewById<Button>(Resource.Id.button3);
            button.Click += delegate
            {
                count++;
                TextView.Text = count.ToString();
            };
            
            Second_Activity_Button.Click += Second_Activity_Button_Click;
            Third_Activity_Button.Click += Third_Activity_Button_Click;
        }

        private void Third_Activity_Button_Click(object sender, System.EventArgs e)
        {
            var thirdActivity = new Intent(this, typeof(ThirdActivity));
            StartActivity(thirdActivity);
        }

        private void Second_Activity_Button_Click(object sender, System.EventArgs e)
        {
            var secondActivity = new Intent(this, typeof(SecondActivity));
            StartActivity(secondActivity);
        }
    }
}