using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace FragmentSample
{
    [Activity(Label = "AddPost")]
    public class AddPost : Activity
    {
        private dbService dbService;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.AddPost);

            Button saveBtn = FindViewById<Button>(Resource.Id.SaveBtn);

            saveBtn.Click += SaveOnClick;

        }

        private void SaveOnClick(object sender, EventArgs e)
        {
            dbService = new dbService();
            NoteModel note = new NoteModel();
            dbService.CreateDatabase();
            note.Dialogue = FindViewById<EditText>(Resource.Id.DialogueEditText).Text;
            note.Title = FindViewById<EditText>(Resource.Id.TitleEditText).Text;
            dbService.AddPost(note);
            dbService.CreateDatabase();
            StartActivity(typeof(MainActivity));
        }
    }
}