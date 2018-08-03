using System;
using System.Collections.Generic;
using Android.Graphics;
using Android.Views;
using Android.Widget;
using Java.Lang;
using Tangent.Employee.Core.Models;

namespace Tangent.Employee.Droid.Adapters
{
    public class DashboardAdapter : BaseAdapter
    {
        List<DashboardItem> _dashboardList;

        public DashboardAdapter(List<DashboardItem> items)
        {
            this._dashboardList = items;
        }

        public override int Count 
        {
            get
            {
                return _dashboardList == null ? 0 : _dashboardList.Count;
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
            if (convertView == null)
            {
                convertView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.item_dashboard, parent, false);
            }

            var tvName = convertView.FindViewById<TextView>(Resource.Id.tv_metric_label);
            var tvValue = convertView.FindViewById<TextView>(Resource.Id.tv_metric_value);
            var tvDetails = convertView.FindViewById<TextView>(Resource.Id.tv_details);

            var dashboardItem = _dashboardList[position];

            tvName.Text = dashboardItem.Name;
            tvValue.Text = dashboardItem.Value;

            convertView.SetBackgroundColor(GetColor(position));

            return convertView;
        }

        private Color GetColor(int position)
        {
            var colors = new Color[]
            {
                Color.ParseColor("#42A5F5"),
                Color.ParseColor("#26A69A"),
                Color.ParseColor("#D500F9"),
                Color.ParseColor("#FF5722"),
                Color.ParseColor("#FFD600"),
                Color.ParseColor("#2C3571"),
                Color.ParseColor("#F02E2E")
            };

            if (position <= colors.Length)
            {
                return colors[position];
            }

            return colors[0];
        }
    }
}
