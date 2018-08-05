using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.OS;
using Android.Views;
using Android.Widget;
using Tangent.Employee.Core.Models;
using Tangent.Employee.Core.Services.Interface;
using Tangent.Employee.Droid.Adapters;
using Tangent.Employee.Droid.Extentions;
using Tangent.Employee.Droid.Utils;
using Fragment = Android.Support.V4.App.Fragment;

namespace Tangent.Employee.Droid.Fragments
{
    public class DashboardFragment : BaseFragment
    {
        readonly string TAG = typeof(DashboardFragment).FullName;

        View _contentView;
        TextView _tvFullname;
        TextView _tvGreeting;
        GridView _gridView;
        DashboardAdapter _adapter;
        ProgressBar _pbLoadingIndicator;

        IEmployeeService _employeeService; 

        List<DashboardItem> _items;
        Dictionary<string, List<Core.Models.Employee>> _employeeDictionary;

        Action<List<Core.Models.Employee>> _employeeSelectHandler = delegate { };
        Action<List<Review>> _reviewSelectHandler = delegate { };
        //internal List<Review> _reviews;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        public static Fragment NewInstance(IEmployeeService employeeService, Action<List<Core.Models.Employee>> onEmployeeTypeSelected, Action<List<Review>> onReviewTileSelected)
        {
            var fragment = new DashboardFragment();
            fragment._employeeService = employeeService;
            fragment._employeeSelectHandler = onEmployeeTypeSelected;
            fragment._reviewSelectHandler = onReviewTileSelected;
            return fragment;
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View view = inflater.Inflate(Resource.Layout.fragment_dashboard, container, false);

            _gridView = view.FindViewById<GridView>(Resource.Id.gridview);
            _tvFullname = view.FindViewById<TextView>(Resource.Id.tv_full_name);
            _tvGreeting = view.FindViewById<TextView>(Resource.Id.tv_greeting);
            _contentView = view.FindViewById(Resource.Id.content_view);
            _pbLoadingIndicator = view.FindViewById<ProgressBar>(Resource.Id.pb_loading_indicator);

            return view;
        }

        public async override void OnViewCreated(View view, Bundle savedInstanceState)
        {
            base.OnViewCreated(view, savedInstanceState);
            (this.Activity as MainActivity).SetCustomTitle("Dashboard");

            _employeeDictionary = new Dictionary<string, List<Core.Models.Employee>>();
            _items = new List<DashboardItem>();

            _pbLoadingIndicator.Visibility = ViewStates.Visible;
            var employees = await _employeeService.GetAllEmployeesAsync(AccessToken);
            if (employees == null)
            {
                ShowErrorDialog();
                return;
            }

            var firstName = UserProfileSingleton.Instance.GetUserProfile().User.FirstName;
            var lastName = UserProfileSingleton.Instance.GetUserProfile().User.LastName;
            _tvFullname.Text = $"Hello {firstName} {lastName}";

            var birthdays = await _employeeService.GetBirthdays(employees);
            var males = await _employeeService.GetEmployeeByGender(employees, "M");
            var females = await _employeeService.GetEmployeeByGender(employees, "F");
            var frontEnds = await _employeeService.GetEmployeePosition(employees, "Front-end Developer");
            var backEnds = await _employeeService.GetEmployeePosition(employees, "Back-end Developer");
            var projectManagers = await _employeeService.GetEmployeePosition(employees, "Project Manager");

            _employeeDictionary.Add("Employees", employees.ToList());
            _employeeDictionary.Add("Birthdays", birthdays.ToList());
            _employeeDictionary.Add("Project Managers", projectManagers.ToList());
            _employeeDictionary.Add("Front-end Developers", frontEnds.ToList());
            _employeeDictionary.Add("Back-end Developers", backEnds.ToList());
            _employeeDictionary.Add("Males", males.ToList());
            _employeeDictionary.Add("Females", females.ToList());

            for (int i = 0; i < _employeeDictionary.Count; i++)
            {
                string _key = _employeeDictionary.ElementAt(i).Key;

                _items.Add(new DashboardItem()
                {
                    Name = _employeeDictionary.ElementAt(i).Key,
                    Value = _employeeDictionary[_key].Count.ToString()
                });
            }

            _items.Add(new DashboardItem 
            {
                Name = "Reviews", 
                Value = UserProfileSingleton.Instance.GetUserProfile().Review.Count.ToString()
            });

            _pbLoadingIndicator.Visibility = ViewStates.Gone;

            _adapter = new DashboardAdapter(_items);
            _gridView.Adapter = _adapter;
            _gridView.ItemClick += GridView_ItemClick;
        }

        public override void OnResume()
        {
            base.OnResume();
        }

        public override void OnDetach()
        {
            base.OnDetach();
            _employeeSelectHandler = null;
        }

        void GridView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            if(e.Position == 7)
            {
                var review = UserProfileSingleton.Instance.GetUserProfile().Review;
                _reviewSelectHandler(review);
                return;
            }

            var key = _employeeDictionary.ElementAt(e.Position).Key;
            var employees = _employeeDictionary[key];
            _employeeSelectHandler(employees);
        }

        void ShowErrorDialog()
        {
            Helpers.ShowDialog(Activity, GetString(Resource.String.error_title), GetString(Resource.String.error_retrieving_employees));
        }
    }
}
