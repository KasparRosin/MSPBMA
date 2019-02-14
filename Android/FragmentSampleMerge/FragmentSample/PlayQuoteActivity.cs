using System.Linq;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
using Android.Widget;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using System;

namespace FragmentSample
{
    [Activity(Label = "PlayQuoteActivity", Theme = "@style/AppTheme")]
    public class PlayQuoteActivity : Activity
    {
        private int PlayId;
        private dbService db = new dbService();
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            if (Resources.Configuration.Orientation == Android.Content.Res.Orientation.Landscape)
            {
                Finish();
            }
            SetContentView(Resource.Layout.ShowQuote);
            PlayId = Intent.Extras.GetInt("current_play_id", 0);
            TextView text = FindViewById<TextView>(Resource.Id.Dialogue);
            Button SaveEdit = FindViewById<Button>(Resource.Id.EditSaveBtn);
            Button DeleteCancel = FindViewById<Button>(Resource.Id.DeleteCancelBtn);



            db.CreateDatabase();
            NoteModel[] noteModels = db.GetAllPosts().ToArray();
            string[] Text = noteModels.Select(i => i.Dialogue).ToArray();
            text.Text = Text[PlayId];
            SaveEdit.Click += Saveedit_Click;
            DeleteCancel.Click += DeleteCancel_Click;
            
            
        }

        private void DeleteCancel_Click(object sender, EventArgs e)
        {
            db.CreateDatabase();
            NoteModel Post2Delete = db.GetNote(PlayId + 1);
            db.DeletePost(Post2Delete);
            db.CreateDatabase();
            StartActivity(typeof(MainActivity));
        }

        private void Saveedit_Click(object sender, EventArgs e)
        {            
            if(FindViewById<Button>(Resource.Id.EditSaveBtn).Text == "Edit")
            {
                TextView CurrentText = FindViewById<TextView>(Resource.Id.Dialogue);
                var TextToEdit = CurrentText.Text;
                FindViewById<EditText>(Resource.Id.DialogueEditText).Visibility = ViewStates.Visible;
                FindViewById<EditText>(Resource.Id.DialogueEditText).Text = TextToEdit;
                CurrentText.Visibility = ViewStates.Gone;
                FindViewById<Button>(Resource.Id.EditSaveBtn).Text = "Save";
                FindViewById<Button>(Resource.Id.DeleteCancelBtn).Text = "Cancel";      
            }
            else if(FindViewById<Button>(Resource.Id.EditSaveBtn).Text == "Save")
            {
                var TextToSave = FindViewById<EditText>(Resource.Id.DialogueEditText).Text;
                FindViewById<EditText>(Resource.Id.DialogueEditText).Visibility = ViewStates.Gone;
                FindViewById<TextView>(Resource.Id.Dialogue).Visibility = ViewStates.Visible;
                FindViewById<TextView>(Resource.Id.Dialogue).Text = TextToSave;
                FindViewById<Button>(Resource.Id.EditSaveBtn).Text = "Edit";
                FindViewById<Button>(Resource.Id.DeleteCancelBtn).Text = "Delete";
                db.CreateDatabase();
                NoteModel[] noteModels = db.GetAllPosts().ToArray();
                string[] Text = noteModels.Select(i => i.Title).ToArray();
                db.EditNote(TextToSave, PlayId + 1);
                db.CreateDatabase();
            }
        }
    }
}