﻿using GuilanGame.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace GuilanGame.DataAccessLayer
{
    public class RecordData
    {

        public RecordData()
        {

            Records = App.CurrentApp.Configuration.RecordData;

            ViewRecords.CollectionChanged += ViewRecords_CollectionChanged;

        }

        private void ViewRecords_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            var view = sender as ICollectionView;

            view.MoveCurrentToFirst();
            RecordItem previous = null;
            while (!view.IsCurrentAfterLast)
            {
                var current = (view.CurrentItem as RecordItem);

                current.Rank = (previous == null) ? 1 :
                               (previous.Score == current.Score) ? previous.Rank :
                               previous.Rank + 1;

                previous = current;

                view.MoveCurrentToNext();
            }
        }

        public ObservableCollection<RecordItem> Records { get; private set; }

        public ICollectionView ViewRecords
        {
            get
            {
                var view = CollectionViewSource.GetDefaultView(Records);
                view.SortDescriptions.Add(new SortDescription() {
                    PropertyName = nameof(RecordItem.Score),
                    Direction = ListSortDirection.Descending
                });

                return view;
            }
        }

    }
}
