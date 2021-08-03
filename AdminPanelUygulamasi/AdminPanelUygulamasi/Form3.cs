using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace AdminPanelUygulamasi
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void search_data_Click(object sender, EventArgs e)
        {
            var point =new PointLatLng(Convert.ToDouble(txtlat.Text), Convert.ToDouble(txtLong.Text));
            LoadMap(point);
            AddMarker(point);

            map.DragButton = MouseButtons.Left;
            map.MapProvider = GMapProviders.GoogleMap;
            double lat = Convert.ToDouble(txtlat.Text);
            double lng = Convert.ToDouble(txtLong.Text);

            map.Position = new GMap.NET.PointLatLng(lat, lng);
            map.MinZoom = 1;
            map.MaxZoom = 100;
            map.Zoom = 10;

           
        }


        private void map_MouseClick(object sender, MouseEventArgs e)
        {
            var point = map.FromLocalToLatLng(e.X, e.Y);
            double lat = point.Lat;
            double lng = point.Lng;

            txtlat.Text = lat + "";
            txtLong.Text = lng + "";

            LoadMap(point);

            AddMarker(point);

            if (map.Overlays.Count > 0)
            {
                map.Overlays.RemoveAt(0);
                map.Refresh();
            }


        }

        private void LoadMap(PointLatLng point)
        {
            map.Position = point;
        }

        private void AddMarker(PointLatLng pointToAdd, GMarkerGoogleType markerType = GMarkerGoogleType.red_pushpin)
        {
            var markers = new GMapOverlay("markers");
            var marker = new GMarkerGoogle(pointToAdd, markerType);
            markers.Markers.Add(marker);
            map.Overlays.Add(markers);
        }


    }
}
