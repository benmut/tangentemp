using System;
using System.Collections.Generic;
using Android.Views;
using Android.Widget;
using Java.Lang;
using Tangent.Employee.Core.Models;

namespace Tangent.Employee.Droid.Adapters
{
    public class ReviewAdapter : BaseAdapter
    {
        List<Review> _reviews;

        public ReviewAdapter(List<Review> reviews)
        {
            _reviews = reviews;
        }

        public override int Count
        {
            get
            {
                return _reviews == null ? 0 : _reviews.Count;
            }
        }

        public override Java.Lang.Object GetItem(int position)
        {
            throw new NotImplementedException();
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View view = null;

            if (convertView == null)
            {
                view = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.item_review, null);
            }
            else
            {
                view = convertView;
            }

            TextView _reviewNumber = (TextView)view.FindViewById(Resource.Id.tv_review_number);

            _reviewNumber.Text = position.ToString();  

            return view;
        }
    }
}
