using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Collections;
using System.Drawing;

namespace SchedulerFetchCustomObjects {
#region #customappointment
    public class CustomAppointment : IEditableObject {
        DateTime fStart;
        DateTime fEnd;
        string fSubject;
        int fStatus;
        string fDescription;
        long fLabel;
        string fLocation;
        bool fAllday;
        int fEventType;
        string fRecurrenceInfo;
        string fReminderInfo;
        object fOwnerId;

        CustomEventList events;
        bool committed = false;

        public CustomAppointment(CustomEventList events) {
            this.events = events;
        }

        private void OnListChanged() {
            int index = events.IndexOf(this);
            events.OnListChanged(new ListChangedEventArgs(ListChangedType.ItemChanged, index));
        }

        public DateTime StartTime { get { return fStart; } set { fStart = value; } }
        public DateTime EndTime { get { return fEnd; } set { fEnd = value; } }
        public string Subject { get { return fSubject; } set { fSubject = value; } }
        public int Status { get { return fStatus; } set { fStatus = value; } }
        public string Description { get { return fDescription; } set { fDescription = value; } }
        public long Label { get { return fLabel; } set { fLabel = value; } }
        public string Location { get { return fLocation; } set { fLocation = value; } }
        public bool AllDay { get { return fAllday; } set { fAllday = value; } }
        public int EventType { get { return fEventType; } set { fEventType = value; } }
        public string RecurrenceInfo { get { return fRecurrenceInfo; } set { fRecurrenceInfo = value; } }
        public string ReminderInfo { get { return fReminderInfo; } set { fReminderInfo = value; } }
        public object OwnerId { get { return fOwnerId; } set { fOwnerId = value; } }

        public void BeginEdit() {
        }
        public void CancelEdit() {
            if (!committed) {
                ((IList)events).Remove(this);
            }
        }
        public void EndEdit() {
            committed = true;
        }
    }
#endregion #customappointment

#region #customeventlist
    public class CustomEventList : CollectionBase, IBindingList {
        public CustomAppointment this[int idx] { get { return (CustomAppointment)base.List[idx]; } }

        public new void Clear() {
            base.Clear();
            OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, -1));
        }
        public void Add(CustomAppointment appointment) {
            base.List.Add(appointment);
        }
        public int IndexOf(CustomAppointment appointment) {
            return List.IndexOf(appointment);
        }
        public object AddNew() {
            CustomAppointment app = new CustomAppointment(this);
            List.Add(app);
            return app;
        }
        public bool AllowEdit { get { return true; } }
        public bool AllowNew { get { return true; } }
        public bool AllowRemove { get { return true; } }

        private ListChangedEventHandler listChangedHandler;
        public event ListChangedEventHandler ListChanged {
            add { listChangedHandler += value; }
            remove { listChangedHandler -= value; }
        }
        internal void OnListChanged(ListChangedEventArgs args) {
            if (listChangedHandler != null) {
                listChangedHandler(this, args);
            }
        }
        protected override void OnRemoveComplete(int index, object value) {
            OnListChanged(new ListChangedEventArgs(ListChangedType.ItemDeleted, index));
        }
        protected override void OnInsertComplete(int index, object value) {
            OnListChanged(new ListChangedEventArgs(ListChangedType.ItemAdded, index));
        }

        public void AddIndex(PropertyDescriptor pd) { throw new NotSupportedException(); }
        public void ApplySort(PropertyDescriptor pd, ListSortDirection dir) { throw new NotSupportedException(); }
        public int Find(PropertyDescriptor property, object key) { throw new NotSupportedException(); }
        public bool IsSorted { get { return false; } }
        public void RemoveIndex(PropertyDescriptor pd) { throw new NotSupportedException(); }
        public void RemoveSort() { throw new NotSupportedException(); }
        public ListSortDirection SortDirection { get { throw new NotSupportedException(); } }
        public PropertyDescriptor SortProperty { get { throw new NotSupportedException(); } }
        public bool SupportsChangeNotification { get { return true; } }
        public bool SupportsSearching { get { return false; } }
        public bool SupportsSorting { get { return false; } }
    }
#endregion #customeventlist

#region #customresource
    public class CustomResource {
        string name;
        int res_id;
        Color res_color;

        public string Name { get { return name; } set { name = value; } }        
        public int ResID { get { return res_id; } set { res_id = value; } }
        public Color ResColor { get { return res_color; } set { res_color = value; } }

        public CustomResource() {
        }
    }
#endregion #customresource

#region #customresourcecollection
    public class CustomResourceCollection : CollectionBase, IBindingList {
        public CustomResourceCollection() {
        }
        public CustomResource this[int idx] { get { return (CustomResource)base.List[idx]; } }

        public void Add(CustomResource res) {
            List.Add(res);
        }
        public new void Clear() {
            base.Clear();
            OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, -1));
        }
        protected override void OnRemoveComplete(int index, object value) {
            OnListChanged(new ListChangedEventArgs(ListChangedType.ItemDeleted, index));
        }
        protected override void OnInsertComplete(int index, object value) {
            OnListChanged(new ListChangedEventArgs(ListChangedType.ItemAdded, index));
        }
        #region IBindingList implementation
        ListChangedEventHandler listChangedHandler;
        public event ListChangedEventHandler ListChanged { add { listChangedHandler += value; } remove { listChangedHandler -= value; } }
        internal void OnListChanged(ListChangedEventArgs args) {
            if (listChangedHandler != null) listChangedHandler(this, args);
        }
        public bool AllowEdit { get { return true; } }
        public bool AllowNew { get { return true; } }
        public bool AllowRemove { get { return true; } }

        public bool IsSorted { get { return false; } }
        public ListSortDirection SortDirection { get { throw new NotSupportedException(); } }
        public PropertyDescriptor SortProperty { get { throw new NotSupportedException(); } }

        public bool SupportsChangeNotification { get { return true; } }
        public bool SupportsSearching { get { return false; } }
        public bool SupportsSorting { get { return false; } }

        public object AddNew() {
            CustomResource res = new CustomResource();
            Add(res);
            return res;
        }
        public void AddIndex(PropertyDescriptor pd) { throw new NotSupportedException(); }
        public void ApplySort(PropertyDescriptor pd, ListSortDirection dir) { throw new NotSupportedException(); }
        public int Find(PropertyDescriptor property, object key) { throw new NotSupportedException(); }
        public void RemoveIndex(PropertyDescriptor pd) { throw new NotSupportedException(); }
        public void RemoveSort() { throw new NotSupportedException(); }
       #endregion
    }
#endregion #customresourcecollection

}
