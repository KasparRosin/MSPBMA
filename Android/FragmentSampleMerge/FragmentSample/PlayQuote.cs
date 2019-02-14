using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace FragmentSample
{
    public class PlayQuote : Fragment
    {
        private dbService db = new dbService();
        public int PlayId => Arguments.GetInt("current_play_id", 0);

        public static PlayQuote NewInstance(int playId)
        {
            var bundle = new Bundle();
            bundle.PutInt("current_play_id", playId);
            return new PlayQuote { Arguments = bundle };
        }

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            if (container == null)
            {
                return null;
            }

            var textView = new TextView(Activity);
            var padding = Convert.ToInt32(TypedValue.ApplyDimension(ComplexUnitType.Dip, 4, Activity.Resources.DisplayMetrics));
            textView.SetPadding(padding, padding, padding, padding);
            textView.TextSize = 24;
            db.CreateDatabase();

            
            NoteModel[] noteModels = db.GetAllPosts().ToArray();
            string[] Text = noteModels.Select(i => i.Dialogue).ToArray();
            textView.Text = Text[PlayId];
            
            var scroller = new ScrollView(Activity);
            scroller.AddView(textView);
            return scroller;
        }
    }
}