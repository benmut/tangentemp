using System;
using System.Collections.Generic;
using Android.Views;
using Android.Widget;
using Java.Lang;

namespace Tangent.Employee.Droid.Adapters
{
    public class EmployeeCategoryAdapter : BaseAdapter
    {
        private List<Core.Models.Employee> _employeeList;

        public EmployeeCategoryAdapter(List<Core.Models.Employee> items)
        {
            _employeeList = items;
        }

        public override int Count
        {
            get
            {
                return _employeeList == null ? 0 : _employeeList.Count;
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
                view = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.item_employee_category, null);
            }
            else
            {
                view = convertView;
            }

            ImageView _placeImage = (ImageView)view.FindViewById(Resource.Id.iv_place_image);
            TextView _fullname = (TextView)view.FindViewById(Resource.Id.tv_full_name);
            TextView _position = (TextView)view.FindViewById(Resource.Id.tv_position);

            var employee = _employeeList[position];

            _placeImage.SetImageBitmap(null);
            _fullname.Text = employee.User.FirstName + " " + employee.User.LastName;
            _position.Text = employee.Position.Name;

            return view;
        }
    }
}
