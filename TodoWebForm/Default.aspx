<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TodoWebForm._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <h2>My Tasks</h2>

    <div class="form-inline">
        <div class="form-group">
            <label class="sr-only" for="txtSubject">Subject</label>
            <asp:TextBox ClientIDMode="Static" ID="txtSubject" runat="server" CssClass="form-control" ToolTip="Subject"></asp:TextBox>
        </div>
        <div class="checkbox">
            <label>
                <asp:CheckBox ID="chkIsComplete" runat="server" ClientIDMode="Static" />
                Is Complete
            </label>
        </div>
        <asp:Button ID="Button1" runat="server" Text="Add" CssClass="btn btn-primary" OnClick="Button1_Click" />
        <asp:Button ID="Button2" runat="server" Text="Add with Error" CssClass="btn btn-danger ml-2" OnClick="Button2_Click" />
    </div>

    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="100%" DataKeyNames="TaskId" DataSourceID="SqlDataSource1" CssClass="table table-bordered">
        <Columns>
            <asp:BoundField DataField="TaskId" HeaderText="TaskId" SortExpression="TaskId" InsertVisible="False" ReadOnly="True" />
            <asp:BoundField DataField="Subject" HeaderText="Subject" SortExpression="Subject" />
            <asp:CheckBoxField DataField="IsComplete" HeaderText="IsComplete" SortExpression="IsComplete" />
        </Columns>
        <EmptyDataTemplate>
            No task.
        </EmptyDataTemplate>
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ToDoDbConnectionString %>" SelectCommand="SELECT * FROM [TaskItem]" DeleteCommand="DELETE FROM [TaskItem] WHERE [TaskId] = @TaskId" InsertCommand="INSERT INTO [TaskItem] ([Subject], [IsComplete]) VALUES (@Subject, @IsComplete)" UpdateCommand="UPDATE [TaskItem] SET [Subject] = @Subject, [IsComplete] = @IsComplete WHERE [TaskId] = @TaskId">
        <DeleteParameters>
            <asp:Parameter Name="TaskId" Type="Int64" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="Subject" Type="String" />
            <asp:Parameter Name="IsComplete" Type="Boolean" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="Subject" Type="String" />
            <asp:Parameter Name="IsComplete" Type="Boolean" />
            <asp:Parameter Name="TaskId" Type="Int64" />
        </UpdateParameters>
    </asp:SqlDataSource>
</asp:Content>
