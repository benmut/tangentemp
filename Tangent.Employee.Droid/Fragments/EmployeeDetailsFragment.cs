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
using Fragment = Android.Support.V4.App.Fragment;

namespace Tangent.Employee.Droid.Fragments
{
    public class EmployeeDetailsFragment : BaseFragment
    {
        readonly string TAG = typeof(EmployeeDetailsFragment).FullName;

        TextView _id, _userName, _position, _emailAddress, _phoneNumber;
        TextView _githubUser, _birthDate, _gender, _race, _yearsWorked, _age;

        Core.Models.Employee _employee;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        public static Fragment NewInstance(Core.Models.Employee employee)
        {
            var fragment = new EmployeeDetailsFragment();
            fragment._employee = employee;

            return fragment;
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View view = inflater.Inflate(Resource.Layout.fragment_employee_details, container, false);

            _id = (TextView)view.FindViewById(Resource.Id.tv_id);
            _userName = (TextView)view.FindViewById(Resource.Id.tv_username);
            _position = (TextView)view.FindViewById(Resource.Id.tv_position);
            _emailAddress = (TextView)view.FindViewById(Resource.Id.tv_email);
            _phoneNumber = (TextView)view.FindViewById(Resource.Id.tv_phone_number);
            _githubUser = (TextView)view.FindViewById(Resource.Id.tv_github);
            _birthDate = (TextView)view.FindViewById(Resource.Id.tv_birth_date);
            _gender = (TextView)view.FindViewById(Resource.Id.tv_gender);
            _race = (TextView)view.FindViewById(Resource.Id.tv_race);
            _yearsWorked = (TextView)view.FindViewById(Resource.Id.tv_years_worked);
            _age = (TextView)view.FindViewById(Resource.Id.tv_age);

            return view;
        }

        public override void OnViewCreated(View view, Bundle savedInstanceState)
        {
            base.OnViewCreated(view, savedInstanceState);
            (this.Activity as MainActivity).SetCustomTitle("Employee Details");

            _id.Text = _employee.User.Id;
            _userName.Text = _employee.User.Username;
            _position.Text = $"{_employee.Position.Level} {_employee.Position.Name}";
            _emailAddress.Text = _employee.Email;
            _phoneNumber.Text = _employee.PhoneNumber;
            _githubUser.Text = _employee.GithubUser;
            _birthDate.Text = _employee.Birthdate;
            _gender.Text = _employee.Gender;
            _race.Text = _employee.Race;
            _yearsWorked.Text = _employee.YearsWorked;
            _age.Text = _employee.Age;
        }

        public override void OnResume()
        {
            base.OnResume();
        }
    }
}
