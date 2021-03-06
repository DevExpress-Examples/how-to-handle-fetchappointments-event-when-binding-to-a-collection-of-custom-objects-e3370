<!-- default file list -->
*Files to look at*:

* [CustomObjects.cs](./CS/CustomObjects.cs) (VB: [CustomObjects.vb](./VB/CustomObjects.vb))
* [Form1.cs](./CS/Form1.cs) (VB: [Form1.vb](./VB/Form1.vb))
* [Program.cs](./CS/Program.cs) (VB: [Program.vb](./VB/Program.vb))
<!-- default file list end -->
# How to handle FetchAppointments event when binding to a collection of custom objects


<p>This example illustrates how to correctly handle the <a href="http://documentation.devexpress.com/#CoreLibraries/DevExpressXtraSchedulerSchedulerStorageBase_FetchAppointmentstopic"><u>SchedulerStorageBase.FetchAppointments Event</u></a> when the SchedlerControl is bound to a collection of custom object (see <a href="https://www.devexpress.com/Support/Center/p/E750">How to bind the SchedulerControl to a collection of custom objects</a>). Although this scenario has a little practical sense (generally, handling this event is appropriate when using an external datasource), the corresponding example is very useful from the technical point of you. It clearly shows that you should not modify the <strong>SchedulerStorage.Appointments</strong> or <strong>SchedulerStorage.Appointments.DataSource</strong> property directly in the FetchAppointments event handler (to be more precise, this is not correct). Instead, you should update (add/remove items) the collection that is assigned to the <strong>SchedulerStorage.Appointments.DataSource</strong> property. Note that it is the most important part of this example. Also, it shows how the <a href="http://documentation.devexpress.com/#WindowsForms/DevExpressXtraSchedulerDateNavigator_BoldAppointmentDatestopic"><u>DateNavigator.BoldAppointmentDates Property</u></a> value affect the fetch interval. Please review the <a href="http://documentation.devexpress.com/#WindowsForms/CustomDocument8385"><u>FetchAppointments Event - Tackling Large Datasets</u></a> help section for more information.</p>

<br/>


