using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Members;
using System.Data;

public partial class Usercontrols_calendarUserCtrl : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //define the value of FromTime and ToTime
        FromTime = this.fromCalendar.SelectedDate.Date;
        ToTime = this.toCalendar.SelectedDate.Date;
    }

    //properties
    private DateTime fromTime;
    public DateTime FromTime
    {
        get;
        set;
    }

    private DateTime toTime;
    public DateTime ToTime
    {
        get;
        set;
    }

}