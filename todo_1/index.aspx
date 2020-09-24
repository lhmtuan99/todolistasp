<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="todo_1.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">

    <title><%: Page.Title %> </title>
    <link href="Css/bootstrap-4.3.1.css" rel="stylesheet" type="text/css">
    <link href="Css/style.css" rel="stylesheet" type="text/css">
    <link href="Css/font-awesome.css" rel="stylesheet" type="text/css">
    <script src="https://use.fontawesome.com/releases/v5.14.0/js/all.js" data-auto-replace-svg="nest"></script>

</head>
<body >
   
    <asp:Label ID="label1" runat="server" ><%=title%></asp:Label>

    <div class="container-fluid bg-nen">
    	<div class="text-center">
            <form runat="server">

           
            <asp:GridView ID="GridView1" runat="server">
            </asp:GridView>
            </form>
           
                logo</div>
        <form action="index.aspx" method="get">
            <span>Date<input type="date"  name="daysearch" value="29-02-2020"  /></span>
            <button>tim kiem</button>
        </form>
        
        <h4>To do list</h4>
        <!--content-->
        <div class="container">
            <div class="row">
                <% string[] Weeks = new string[10];
                    Weeks[0] = "Monday";
                    Weeks[1] = "Tuesday";
                    Weeks[2] = "Wednesday";
                    Weeks[3] = "Thursday";
                    Weeks[4] = "Friday";
                    Weeks[5] = "Saturday";

                    for (int i = 0; i <6; i++)
                    {
                        DateTime dtime = new DateTime();%>
                    <div class="col-4">
                    <div class="day">
                    	
                            <h4 class="tittle">Thứ <%= i+2 %></h4>
                            
                           <%for (int j = 0; j < dt.Rows.Count; j++) {
                                   dtime = (DateTime)dt.Rows[j][2];
                            
                                   if(dtime.DayOfWeek.ToString().Equals(Weeks[i]))
                                   {%>
                                        <div class="bg-white">
                                <div class="activity">
                                	<div class="form-inline">
                                        <form action="index.aspx" method="get" class="form-sua form-inline">
                                        <input type="text" name="idupdate" value="<%= dt.Rows[j][0] %>" hidden />
                                        <input name="textupdate" class="text-edit form-control mr-4" type="text" disabled value="<%= dt.Rows[j][1] %>">
                                        <button hidden><i class="fa fa-plus"></i></button>
                                            
                                        <div class="bg-edit">
                                            <span style="padding: 3px" class="edit btn-primary" ><i class="fa fa-edit"></i></span>
                                        </div>
                                            </form>
                                        <div class="bg-hover d-inline" id="<%= dt.Rows[j][0] %>">
                                            <form action="index.aspx" method="get" >
                                                <input  name="iddelete" value="<%= dt.Rows[j][0] %>" hidden/>
                                        	    <button runat="server" class="edit btn-danger"><i class="fas fa-times"></i> </button>
                                            </form>
                                          </div>
                                    </div>
                                
                                	<ul class="form-inline">
                                     
                                      <%if (contacts[(int)dt.Rows[j][0], 0] != null)
                                            {
                                                int z = 0;
                                                while (contacts[(int)dt.Rows[j][0], z] != null)
                                                {%>
                                                    
                                                        
                                                        <form action="index.aspx" method="get" >
                                                            <li class="btn btn-info"><%=contacts[(int)dt.Rows[j][0],z] %>
                                                                <input type="text" name="namecontact" value="<%=idcontacts[(int)dt.Rows[j][0],z++] %>" hidden/>
                                                                <input type="text" name="namecontact_idjob" value="<%=dt.Rows[j][0] %>" hidden/>
                                                                <button class="close">&times;</button>
                                                        </li>
                                                                </form>

                                                    
                                             <% }
                                      }%>
                                       
                                      <li class="input-them item-add btn ">
                                          <form  action="index.aspx" method="get">
                                             <input name="contact" class="add-member form-control" type="text" placeholder="abc@gmail.com">
                                              <input type="text" name="idjob" value="<%=dt.Rows[j][0] %>" hidden />
                                               <button hidden><i class="fa fa-plus"></i></button>
                                              
                                          </form>
                                          </li>
                                        <li class="btn btn-danger btn-them"> 
                                      	<i class="fa fa-plus"></i> 
                                      </li>
                                    </ul>
                                    </div>
                            </div>
                                  <% }
                               } %>
                     

                            <form method="get" action="index.aspx"  >
                            <div id="demo"  class="collapse text-add">
                               <input name="job" class="form-control" placeholder="Nhập công việc mới" ></input>
                               <input name="day" value="<%=Weeks[i] %>" hidden></input>
                                <button hidden><i class="fa fa-plus"></i></button>
                                
                            </div>
                            <span data-toggle="collapse" data-target="#demo" class="btn add-activity">+ Add another card</span>
                    </form>
                                </div>
                </div>
                <%}%>
                    
                           
        <!--end content-->
    </div>
    </div>
    </div>
    
    
    <script src="Scripts/jquery-3.5.1.min.js"></script>
    <script src="Scripts/popper.min.js"></script>
    <script src="Scripts/bootstrap.js"></script>
    <script>
        $(document).ready(function () {
            $(".input-them").slideUp(0);
        });

        $(".bg-edit").click(function () {
            a = $(this).siblings(".text-edit");
            a.prop("disabled", false);
            a.focus();
        });
        $(".bg-hover").click(function () {
            //alert(typeof());
      
            a = $(this).parents(".bg-white");
            a.css("display", "none");
            $.ajax({
                url: 'LoginSuccess/AddRoleForSelectStaff',
                type: "POST",
                data: "{'GivenStaffID':'" + $(this).attr("id") + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    alert(response);
                },
                failure: function (response) {
                    alert(response.d);
                }
            }).done(function (response) {
                alert("done " + response);
            });
 
        });

        var closebtns = document.getElementsByClassName("close");
        var i;

        for (i = 0; i < closebtns.length; i++) {
            closebtns[i].addEventListener("click", function () {
                this.parentElement.style.display = 'none';
             
            });
        }
        $(".btn-them").click(function () {
            b = $(this).siblings(".input-them");
            b.slideToggle();
        });
        $(function () {
            $("#datepicker").datepicker();
        });
    </script>
    
</body>
</html>
