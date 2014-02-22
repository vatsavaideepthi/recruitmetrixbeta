﻿$(document).ready(function ()
{
    $('#addtimesheetform').on('keyup', '.wrkinghours,.othoours', function () {
      
        $('#addtimesheetform').find('.twhours').text('0');
        $('#addtimesheetform').find('.wrkinghours').each(function () {
            
            existingvalue = $('#addtimesheetform').find('.twhours').text();
            totalworkinghours = 0;
            thisworkinghours = isNaN(parseInt($(this).val(), 10))?0:parseInt($(this).val(), 10);
            totalworkinghours = thisworkinghours + (isNaN(parseInt(existingvalue, 10)) ? 0 : parseInt(existingvalue, 10));

                $('#addtimesheetform').find('.twhours').text(totalworkinghours);
           
        });
        
        $('#addtimesheetform').find('.totothours').text('0');
        $('#addtimesheetform').find('.othoours').each(function () {

            existingvalue = $('#addtimesheetform').find('.totothours').text();
            totalworkinghours = 0;
            thisworkinghours = isNaN(parseInt($(this).val(), 10)) ? 0 : parseInt($(this).val(), 10);
            totalworkinghours = thisworkinghours + (isNaN(parseInt(existingvalue, 10)) ? 0 : parseInt(existingvalue, 10));

            $('#addtimesheetform').find('.totothours').text(totalworkinghours);

        });


    });


    $('.taskaddinitiate').click(function () {
        var parenttr = $(this).parents('tr');
        $(parenttr).addClass('tasksheetopen');
        var selecteddate = $(parenttr).find('.lbldate').text();
        $('#modaltitle3').text('Add Tasks For ' + selecteddate);
        $('#addtaskmodal').modal('show');

    });

    $('.savetimesheet').click(function () {

        var objcompany = new company($('#companyinfo').find('.name').text());
        var objclient = new client($('.clientdata').attr('data-id'), $('#clientinfo').find('.name').text());
        var objemployee = new self($('.employeedata').attr('data-id'), $('#employeeinfo').find('.name').text(), $('.employeedata').find('.name').text());
        var itemcollection = []
        $('#addtimesheetform').find('.sheetrow').each(function () {
            var taskitemcollection = [];
            $(this).find('.taskitem').each(function () {
                var taskitems = new taskitem($(this).attr('data-description'), $(this).attr('data-project'), $(this).attr('data-taskhours'))
                taskitemcollection.push(taskitems);
            });
            
            var objitem = new item($('.lbldate').attr('data-date'),
                                $('.wrkinghours').val(),
                                $('.othoours').val(), taskitemcollection);
            itemcollection.push(objitem);
        });

        var objmetadata = new CreateTimeSheetMetadata($('.twhours').text(),$('.totothours').text());
            
            

        var newtimesheet = new timesheet(objcompany, objclient, objemployee,objmetadata, itemcollection);
        Createtimesheet(newtimesheet);
    });

    $('#chscustomerselected').click(function () {
        populateclient($('#companyid').val(), $('#currentclientid').val());
    });

    $('#chsemplaoyeeselected').click(function () {
        populateEmployee($('#companyid').val(), $('#currentemployeeid').val());
    });
    

    $('#addlineitem').on('click', function () {
        var clonetr = $(this).parents('.modal').find('#clonelineitem').clone();
        $(clonetr).removeClass('hide').addClass('lineitem');
        $(clonetr).removeAttr('id');
        $('#tasklisttable').find('tr:last').after(clonetr);
        $(clonetr).find('.taskdescription').focus();
    });
});

function company(title)
{
    this.title = title;
}

function client(id, title)
{
    this.id = id;
    this.title = title;
}

function self(id, title, email)
{
    this.id = id;
    this.title = title;
    this.email = email;
}
function CreateTimeSheetMetadata(totalhours, overtime)
{
    this.totalhours = totalhours;
    this.overtimehours = overtime;
}
function item(date,workhours,overtime,tasklines)
{
    this.date = date;
    this.workhours = workhours;
    this.overtime = overtime;
    this.tasks = new taskline(tasklines);
}

function taskitem(description, project, hours)
{
    this.description = description;
    this.project = project;
    this.hours = hours;
}

function taskline(taskitemcollection)
{
    this.task = taskitemcollection;
}

function lineitem(objitemcollection)
{
    this.item = objitemcollection;
}
function timesheet(paramcompany, paramclient, paramself,parammetadata, itemcollection)
{
    this.company = paramcompany;
    this.client = paramclient;
    this.self = paramself;
    this.metadata = parammetadata;
    this.items = new lineitem(itemcollection);
}



    //#region Data Manipulation

    function populateclient(companyid,customerid)
    {
        var customerinfo = GetCustomerInfo(companyid, customerid);

        $('.clientdata').find('.name').text(customerinfo.name);
        $('#clientinfo').find('.name').text(customerinfo.name);
        $('#clientinfo').find('.email').text(customerinfo.email);
        //$('#clientinfo').find('.company').text(customerinfo.name);
        //$('#clientaddress').find('.line1').text(customerinfo.name);
        //$('#clientaddress').find('.line2').text(customerinfo.name);
        //$('#clientaddress').find('.city').text(customerinfo.name);
        //$('#clientaddress').find('.state').text(customerinfo.name);
        //$('#clientaddress').find('.country').text(customerinfo.name);
        //$('#clientaddress').find('.pincode').text(customerinfo.name);
    }

    function populateEmployee(companyid,customerid)
    {
        var employeeinfo = GetEmployeeInfo(customerid,companyid,'contact');

        $('.employeedata').find('.name').text(employeeinfo.Title);
        $('#employeeinfo').find('.name').text(employeeinfo.Title);
        $('#employeeinfo').find('.email').text(employeeinfo.email);
        //$('#employeeinfo').find('.company').text();
        //$('#employeeaddress').find('.line1').text();
        //$('#employeeaddress').find('.line2').text();
        //$('#employeeaddress').find('.city').text();
        //$('#employeeaddress').find('.state').text();
        //$('#employeeaddress').find('.country').text();
        //$('#employeeaddress').find('.pincode').text();
    }

    function ValidateData()
    {

    }

//#endregion

    $('#tasklisttable').on('keyup', '.taskhours', function () {

       var subtotalamount = parseInt(0, 10);
        $('#tasklisttable').find('.taskhours').each(function () {
                subtotalamount = isNaN(parseInt($(this).val(), 10) + parseInt(subtotalamount, 10)) ? 0 : parseInt($(this).val(), 10) + parseInt(subtotalamount, 10);

                if (subtotalamount > 24) {
                    $('#taskhoursexeed').show();
                    $('#AddTaskSettoDay,#addlineitem').hide();
                }
                else {
                    $('#taskhoursexeed').hide();
                    $('#AddTaskSettoDay,#addlineitem').show()
                    $('#addtaskmodal').find('.tasktotalhrs').text(subtotalamount);
                }
                
        });
    });


    $('#AddTaskSettoDay').click(function () {

        var basetimesheet = $('.timesheetmap').find('tr.tasksheetopen');
        $('#tasklisttable').find('.lineitem').each(function () {
            var tdesc = $(this).find('.taskdescription').val();
            var tprojname = $(this).find('.taskproject').val();
            var thours = $(this).find('.taskhours').val();
            var taskitem = $("<input type='hidden' class='taskitem' />");
            $(taskitem).attr('data-description',tdesc);
            $(taskitem).attr('data-project',tprojname);
            $(taskitem).attr('data-taskhours', thours);
            $(basetimesheet).append(taskitem);

        });

        $('#addtaskmodal').modal('hide');
    });