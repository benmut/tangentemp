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
using Tangent.Employee.Core.Models;
using Tangent.Employee.Droid.Adapters;
using Tangent.Employee.Droid.Extentions;
using Fragment = Android.Support.V4.App.Fragment;

namespace Tangent.Employee.Droid.Fragments
{
    public class ReviewsFragment : BaseFragment
    {
        readonly string TAG = typeof(ReviewsFragment).FullName;

        ListView _lvReviews;

        List<Review> _reviews;
        Action<Review> _reviewSelectHandler = delegate { };

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        public static Fragment NewInstance(List<Review> reviews, Action<Review> onReviewSelected)
        {
            var fragment = new ReviewsFragment();
            fragment._reviews = reviews;
            fragment._reviewSelectHandler = onReviewSelected;
                    
            return fragment;
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View view = inflater.Inflate(Resource.Layout.fragment_reviews, container, false);

            _lvReviews = (ListView)view.FindViewById(Resource.Id.lv_reviews);

            return view;
        }

        public override void OnViewCreated(View view, Bundle savedInstanceState)
        {
            base.OnViewCreated(view, savedInstanceState);
            (this.Activity as MainActivity).SetCustomTitle("Reviews");

            _lvReviews.Adapter = new ReviewAdapter(_reviews);
            _lvReviews.ItemClick += ListView_ItemClick;  
        }

        void ListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var review = _reviews[e.Position];
            _reviewSelectHandler(review);
        }

    }
}
