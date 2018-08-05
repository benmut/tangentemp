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
using Tangent.Employee.Droid.Extentions;
using Fragment = Android.Support.V4.App.Fragment;

namespace Tangent.Employee.Droid.Fragments
{
    public class ReviewDetailsFragment : Fragment
    {
        readonly string TAG = typeof(ReviewDetailsFragment).FullName;

        TextView _tvId;
        TextView _tvDate;
        TextView _tvSalary;
        TextView _tvType;

        Review _review;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        public static Fragment NewInstance(Review review)
        {
            var fragment = new ReviewDetailsFragment();
            fragment._review = review;
            return fragment;
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View view = inflater.Inflate(Resource.Layout.fragment_review_details, container, false);

            _tvId = (TextView)view.FindViewById(Resource.Id.tv_id);
            _tvDate = (TextView)view.FindViewById(Resource.Id.tv_date);
            _tvSalary = (TextView)view.FindViewById(Resource.Id.tv_salary);
            _tvType = (TextView)view.FindViewById(Resource.Id.tv_type);

            return view;
        }

        public override void OnViewCreated(View view, Bundle savedInstanceState)
        {
            base.OnViewCreated(view, savedInstanceState);
            (this.Activity as MainActivity).SetCustomTitle("Review Details");

            _tvId.Text = _review.Id;
            _tvDate.Text = _review.Date;
            _tvSalary.Text = _review.Salary;
            _tvType.Text = _review.Type;
        }

        public override void OnResume()
        {
            base.OnResume();
        }
    }
}
