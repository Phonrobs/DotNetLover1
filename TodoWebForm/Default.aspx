<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TodoWebForm._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Todo</h2>

    <div class="form-inline">
        <label class="my-1 mr-2" for="inlineFormCustomSelectPref">Preference</label>
        <select class="custom-select my-1 mr-sm-2" id="inlineFormCustomSelectPref">
            <option selected>Choose...</option>
            <option value="1">One</option>
            <option value="2">Two</option>
            <option value="3">Three</option>
        </select>

        <div class="custom-control custom-checkbox my-1 mr-sm-2">
            <input type="checkbox" class="custom-control-input" id="customControlInline">
            <label class="custom-control-label" for="customControlInline">Remember my preference</label>
        </div>

        <button type="submit" class="btn btn-primary my-1">Submit</button>
    </div>

    <div class="form-inline">
        <label class="sr-only" for="txtSubject">Subject</label>
        <asp:TextBox ClientIDMode="Static" ID="txtSubject" runat="server" CssClass="form-control mr-sm-2"></asp:TextBox>

        <div class="form-check mr-sm-2">
            <asp:CheckBox ID="chkIsComplete" runat="server" CssClass="form-check-input" ClientIDMode="Static" />
            <label class="form-check-label" for="chkIsComplete">
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
