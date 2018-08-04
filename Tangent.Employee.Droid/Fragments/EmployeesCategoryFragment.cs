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
using Tangent.Employee.Droid.Adapters;
using Tangent.Employee.Droid.Extentions;
using Fragment = Android.Support.V4.App.Fragment;

namespace Tangent.Employee.Droid.Fragments
{
    public class EmployeesCategoryFragment : BaseFragment
    {
        readonly string TAG = typeof(EmployeesCategoryFragment).FullName;

        List<Core.Models.Employee> _employees;

        ListView _lvEmployees;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

        }

        public static Fragment NewInstance(List<Core.Models.Employee> employees)
        {
            var fragment = new EmployeesCategoryFragment();
            fragment._employees = employees;

            return fragment;
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View view = inflater.Inflate(Resource.Layout.fragment_employees_category, container, false);

            _lvEmployees = (ListView)view.FindViewById(Resource.Id.lv_employees);

            return view;
        }

        public override void OnViewCreated(View view, Bundle savedInstanceState)
        {
            base.OnViewCreated(view, savedInstanceState);
            (this.Activity as MainActivity).SetCustomTitle("Employees");

            _lvEmployees.Adapter = new EmployeeCategoryAdapter(_employees);
            _lvEmployees.ItemClick += ListView_ItemClick;
        }

        void ListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
        }

    }
}
