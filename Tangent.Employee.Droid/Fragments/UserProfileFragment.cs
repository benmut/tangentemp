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
using Tangent.Employee.Droid.Extentions;
using Tangent.Employee.Droid.Utils;
using Fragment = Android.Support.V4.App.Fragment;

namespace Tangent.Employee.Droid.Fragments
{
    public class UserProfileFragment : Fragment
    {
        readonly string TAG = typeof(UserProfileFragment).FullName;

        TextView _fullName, _id, _userName, _position, _emailAddress, _phoneNumber, _physicalAddress, _idNumber, _taxNumber;
        TextView _githubUser, _birthDate, _startDate, _endDate, _gender, _race, _yearsWorked, _age, _nextReview, _leaveRemaining;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View view = inflater.Inflate(Resource.Layout.fragment_profile, container, false);

            _fullName = (TextView)view.FindViewById(Resource.Id.tv_full_name);
            _id = (TextView)view.FindViewById(Resource.Id.tv_id);
            _userName = (TextView)view.FindViewById(Resource.Id.tv_username);
            _position = (TextView)view.FindViewById(Resource.Id.tv_position);
            _emailAddress = (TextView)view.FindViewById(Resource.Id.tv_email);
            _phoneNumber = (TextView)view.FindViewById(Resource.Id.tv_phone_number);
            _physicalAddress = (TextView)view.FindViewById(Resource.Id.tv_physical_address);
            _idNumber = (TextView)view.FindViewById(Resource.Id.tv_id_number);
            _taxNumber = (TextView)view.FindViewById(Resource.Id.tv_tax_number);
            _githubUser = (TextView)view.FindViewById(Resource.Id.tv_github);
            _birthDate = (TextView)view.FindViewById(Resource.Id.tv_birth_date);
            _startDate = (TextView)view.FindViewById(Resource.Id.tv_start_date);
            _endDate = (TextView)view.FindViewById(Resource.Id.tv_end_date);
            _gender = (TextView)view.FindViewById(Resource.Id.tv_gender);
            _race = (TextView)view.FindViewById(Resource.Id.tv_race);
            _yearsWorked = (TextView)view.FindViewById(Resource.Id.tv_years_worked);
            _age = (TextView)view.FindViewById(Resource.Id.tv_age);
            _nextReview = (TextView)view.FindViewById(Resource.Id.tv_next_review);
            _leaveRemaining = (TextView)view.FindViewById(Resource.Id.tv_leave_remaining);
             
            return view;
        }

        public override void OnViewCreated(View view, Bundle savedInstanceState)
        {
            base.OnViewCreated(view, savedInstanceState);
            (this.Activity as MainActivity).SetCustomTitle("My Profile");

            var firstName = UserProfileSingleton.Instance.GetUserProfile().User.FirstName;
            var lastName = UserProfileSingleton.Instance.GetUserProfile().User.LastName;

            var level = UserProfileSingleton.Instance.GetUserProfile().Position.Level;
            var position = UserProfileSingleton.Instance.GetUserProfile().Position.Name;

            _fullName.Text = $"{firstName} {lastName}";
            _id.Text = UserProfileSingleton.Instance.GetUserProfile().Id;
            _userName.Text = UserProfileSingleton.Instance.GetUserProfile().User.Username;
            _position.Text = $"{level} {position}";
            _emailAddress.Text = UserProfileSingleton.Instance.GetUserProfile().Email;
            _phoneNumber.Text = UserProfileSingleton.Instance.GetUserProfile().PhoneNumber;
            _physicalAddress.Text = UserProfileSingleton.Instance.GetUserProfile().PhysicalAddress;
            _idNumber.Text = UserProfileSingleton.Instance.GetUserProfile().IdNumber;
            _taxNumber.Text = UserProfileSingleton.Instance.GetUserProfile().TaxNumber;
            _githubUser.Text = UserProfileSingleton.Instance.GetUserProfile().GithubUser;
            _birthDate.Text = UserProfileSingleton.Instance.GetUserProfile().Birthdate;
            _startDate.Text = UserProfileSingleton.Instance.GetUserProfile().StartDate;
            _endDate.Text = UserProfileSingleton.Instance.GetUserProfile().EndDate;
            _gender.Text = UserProfileSingleton.Instance.GetUserProfile().Gender;
            _race.Text = UserProfileSingleton.Instance.GetUserProfile().Race;
            _yearsWorked.Text = UserProfileSingleton.Instance.GetUserProfile().YearsWorked;
            _age.Text = UserProfileSingleton.Instance.GetUserProfile().Age;
            _nextReview.Text = UserProfileSingleton.Instance.GetUserProfile().NextReview; 
            _leaveRemaining.Text = UserProfileSingleton.Instance.GetUserProfile().LeaveRemaining;
        }
    }
}
