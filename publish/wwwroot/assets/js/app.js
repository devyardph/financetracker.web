
function setDateByClass(id, format, timeEnabled) {
    var list = document.getElementsByClassName(id);
    for (var i = 0; i < list.length; i++) {
        var id = '#' + list[i].id;

        $(id).attr("autocomplete", "off");
        $(id).flatpickr({
            monthSelectorType: 'static',
            dateFormat: format,
            enableTime: timeEnabled,
        });
    }
}

function setDateById2(id, format, timeEnabled) {
    var id = '#' + id;
    $(id).attr("autocomplete", "off");
    $(id).flatpickr({
        monthSelectorType: 'static',
        dateFormat: format,
        enableTime: timeEnabled
    });
}

function setDateById(id, format, defaultDateTime, timeEnabled) {
    var id = '#' + id;
    $(id).attr("autocomplete", "off");
    $(id).flatpickr({
        monthSelectorType: 'static',
        dateFormat: format,
        enableTime: timeEnabled,
        defaultDate: defaultDateTime,
        onReady: function (dateObj, dateStr, instance) {
            $('.flatpickr-calendar').each(function () {
                var $this = $(this);
                if ($this.find('.flatpickr-clear').length < 1) {
                    $this.append('<div class="d-flex justify-content-between p-2"><button class="flatpickr-clear btn btn-outline-primary btn-sm">clear</button><button class="flatpickr-close btn btn-outline-primary btn-sm">ok</button></div>');
                    $this.find('.flatpickr-clear').on('click', function () {
                        instance.clear();
                        instance.close();
                    });
                    $this.find('.flatpickr-close').on('click', function () {
                        instance.close();
                    });
                }
            });
        }
    });

}

function setDateRangeById(id, format, startDate,endDate,dotNetHelper) {
    var id = '#' + id;
    $(id).attr("autocomplete", "off");
    $(id).flatpickr({
        mode: "range",
        monthSelectorType: 'static',
        dateFormat: format,
        defaultDate: [
            startDate, // start date
            endDate // end date
        ],
        onReady: function (dateObj, dateStr, instance) {
            $('.flatpickr-calendar').each(function () {
                var $this = $(this);
                if ($this.find('.flatpickr-clear').length < 1) {
                    $this.append('<div class="d-flex justify-content-between p-2"><button class="flatpickr-clear btn btn-outline-primary btn-sm">clear</button><button class="flatpickr-close btn btn-outline-primary btn-sm">ok</button></div>');
                    $this.find('.flatpickr-clear').on('click', function () {
                        instance.clear();
                        instance.close();
                    });
                    $this.find('.flatpickr-close').on('click', function () {
                        instance.close();
                    });
                }
            });
        },
        onChange: function (selectedDates) {
            let start = selectedDates.length > 0 ? selectedDates[0].toISOString() : null;
            let end = selectedDates.length > 1 ? selectedDates[1].toISOString() : null;
            dotNetHelper.invokeMethodAsync("SetDateRange", start, end);
        }

    });

}

function setTimeById(id, min, max) {
    var id = '#' + id;
    $(id).attr("autocomplete", "off");
    $(id).flatpickr({
        enableTime: true,
        noCalendar: true,
        dateFormat: "h:i K",
        //minTime: min,
        //maxTime: max,
    });
}

//WORKING
function setSelect2PickerByClass(dotnetHelper, id, method, values, placeholder)
{
    var list = document.getElementsByClassName(id);
    for (var i = 0; i < list.length; i++) {
        var id = '#' + list[i].id;
        //initialize bootstrap select
        const select2 = $(id);
        if (select2.length) {
            select2.each(function () {
                var $this = $(this);
                $this.wrap('<div class="position-relative"></div>');
                $this.select2({
                    allowClear: true,
                    placeholder: placeholder,
                    dropdownParent: $this.parent()
                });
            });
            //set defaul value
            $(id).val(values).trigger("change");
            //trigger events
            $(id).on('select2:select', function () {
                var selected = $(id).val();
                dotnetHelper.invokeMethodAsync(method, selected);
            });
            $(id).on('select2:unselect', function () {
                var selected = $(id).val();
                dotnetHelper.invokeMethodAsync(method, selected);
            });
        }
    }
}
function resetSelect2PickerById(element, values) {
    var id = '#' + element;
    $(id).val(values).trigger("change");
}

//WORKING
function setSelectPickerByClass(id)
{
    var list = document.getElementsByClassName(id);
    for (var i = 0; i < list.length; i++) {
        var id = '#' + list[i].id;
        //initialize bootstrap select
        const select = $(id);
        if (select.length) {
            select.selectpicker({
                size: '5'
            });
        }
    }
}

//WORKING NOW
function resetSelectPickerById(id, value) {
    const select = $('#' + id);
    setTimeout(() => {
        select.selectpicker('destroy');
        select.selectpicker('val', value);
    }, 100);
}

function refreshSelectPickerByClass(id) {
    var list = document.getElementsByClassName(id);
    setTimeout(() => {
    for (var i = 0; i < list.length; i++) {
        var id = '#' + list[i].id;
        //initialize bootstrap select
            $(id).selectpicker('destroy');
            $(id).selectpicker();
       
        }
    }, 500);
}

function refreshSelectPickerById(component) {
        var id = '#' + component;
        setTimeout(() => {
            $(id).selectpicker('destroy');
            $(id).selectpicker();
        }, 100);
}

function setWizardByClass(id) {
    const wizard = document.querySelector('.' + id);
    if (typeof wizard !== undefined && wizard !== null) {
        const numberedStepper = new Stepper(wizard, {
            linear: false,
            Animation: true
        });
    }
}

function trigger(id) {
    var id = '#' + id;
    $(id).click();
}

function showToast(id) {
    var element = document.getElementById(id);
    var toastr = new bootstrap.Toast(element);
    toastr.show();
}

//SETTING EITHER: SHOW OR HIDE
function setModal(id, setting) {
    var element = '#' + id;
    $(element).modal(setting);
}

function showModal(id) {
    var element = '#' + id;
    setTimeout(function () {
        $(element).modal('show');
    }, 50);
   
}

function hideModal(id) {
    var element = '#' + id;
    setTimeout(function () {
        $(element).modal('hide');
    }, 50);

}

function showOffCanvas(id) {
    var sidebar = $('#' + id);
    sidebar.offcanvas('show');
}

function hideOffCanvas(id) {
    var sidebar = $('#' + id);
    sidebar.offcanvas('hide');
}

function generateOffCanvas(id) {
    const child = new bootstrap.Offcanvas('#' + id);
    child.show();
}

function slimScroll(id){
      const scroller = document.querySelector('#' + id);
      if (typeof scroller !== undefined && scroller !== null) {
          new PerfectScrollbar(document.getElementById(id), {
            wheelPropagation: false
          });
      }
}


function getSuggestions(dotnetHelper, id, suggestions) {
    var element = $("#" + id);
    $(element).suggest("@", {
        data: suggestions,
        map: function (suggestion) {
            return {
                value: suggestion.id,
                text: '<strong>' + suggestion.id + '</strong> <small>' + suggestion.name + '</small>'
            }
        },
        onselect: function (e, item) {
            var content = $(element).val();
            dotnetHelper.invokeMethodAsync('SetText', content)
        }
    })  
  
}


function setValue(id, value) {
    setTimeout(() => {
        $('#' + id).val(value);
    }, 10);
}

function setNumberById(id) {
    var element = document.getElementById(id);
    var maskOptions = {
        mask: Number,  // enable number mask
        scale: 2,  // digits after point, 0 for integers
        thousandsSeparator: ',',  // any single char
        padFractionalZeros: false,  // if true, then pads zeros at end to the length of scale
        normalizeZeros: true,  // appends or removes zeros at ends
        radix: ',',  // fractional delimiter
        mapToRadix: ['.'],  // symbols to process as radix
        min: 0,
        max: 10000000000000,
        autofix: true,
    };
    var mask = IMask(element, maskOptions);
}

function setSelect2ById(id, dotnetHelper, method, placeholder) {
    var element = $('#' + id);
    element.wrap('<div class="position-relative"></div>').select2({
        placeholder: placeholder,
        dropdownParent: element.parent()
    });

    //set defaul value
    //element.val(values).trigger("change");
    //trigger events
    element.on('select2:select', function () {
        var selected = element.val();
        dotnetHelper.invokeMethodAsync(method, selected);
    });
    element.on('select2:unselect', function () {
        var selected = element.val();
        dotnetHelper.invokeMethodAsync(method, selected);
    });
}

function setTagify(id, whitelist, item, dotnetHelper) {
    var element = document.querySelector('#' + id);
    let tagify = new Tagify(element, {
        whitelist: whitelist,
        enforceWhitelist: true,
        maxTags: 10,
        dropdown: {
            maxItems: 10,
            classname: 'tags-inline',
            enabled: 0,
            closeOnSelect: false
        }
    });

    tagify.addTags(item);

    tagify.on('add', function (e) {
        var tagData = e.detail.data;
        var allTags = tagify.getCleanValue();
        const tagValues = allTags.map(tag => tag.value);
        dotnetHelper.invokeMethodAsync('SetTags', tagValues);
    });

    tagify.on('remove', function (e) {
        const removedTag = e.detail.data;
        console.log('Tag removed:', removedTag);

        const remainingTags = tagify.getCleanValue();
        const tagValues = remainingTags.map(tag => tag.value);
        dotnetHelper.invokeMethodAsync('SetTags', tagValues);
    });
}

function setCalendar(dotnetHelper, firstRender, readOnly) {
    var buttons = readOnly ?  'prev,next, today' : 'prev,next, today,addEventButton';
    var calendarEl = document.getElementById('calendar');
    var calendar = new Calendar(calendarEl, {
        initialView: 'dayGridMonth', //timeGridWeek,listWeek,dayGridWeek,dayGridMonth
        plugins: [dayGridPlugin, interactionPlugin, listPlugin, timegridPlugin],
        events: function (fetchInfo, successCallback, failureCallback) {
            var startDate = fetchInfo.startStr;
            var endDate = fetchInfo.endStr;

            dotnetHelper.invokeMethodAsync("FilterByDate", startDate, endDate, firstRender)
                .then(events => {
                    successCallback(events);
                })
                .catch(error => {
                    console.error('Failed to load events:', error);
                    failureCallback(error);
                });
        },
        headerToolbar: {
            right: buttons,
            left: 'dayGridMonth,timeGridWeek,timeGridDay,listMonth',
            center: 'title',
        },
        customButtons: {
            addEventButton: {
                text: '+ New appointment',
                click: function ()
                {
                    dotnetHelper.invokeMethodAsync("EventClicked", "");
                }
            }

        },
        datesSet: function (info) {
           
            const currentRangeStart = info.start;
            const currentRangeEnd = info.end;

            console.log('View changed!');
            console.log('Current view:', info.view.type);
            // You can trigger a fetch or filter here
            calendar.refetchEvents();
        },
        eventClick: function (info) {
            info.jsEvent.preventDefault(); 
            dotnetHelper.invokeMethodAsync("EventClicked", info.event._def.publicId);
        }


    });
    calendar.render();
}


function popover(id, content, dotnetHelper, method) {
    setTimeout(() => {      
        document.querySelectorAll('#' +id+' .surface-btn').forEach(button => {
            const toothId = button.id;
            const toothno = button.dataset.tooth;
            const surface = button.dataset.surface;
            const placement = button.dataset.placement;
            const group = button.dataset.group;

            new bootstrap.Popover(button, {
                html: true,
                title: "<strong>#" + toothno + ' : ' + surface.toUpperCase() + '</strong>',
                content: document.getElementById(content).innerHTML,
                trigger: 'click',
                customClass: 'custom-popover',
                sanitize: false,
                placement: placement
            });

            const popoverInstance = bootstrap.Popover.getInstance(button);
            button.addEventListener('shown.bs.popover', () => {
                const actionButtons = document.querySelectorAll('.condition-btn ');
                actionButtons.forEach(btn => {
                    btn.addEventListener('click', (e) => {
                        const condition = e.target.dataset.condition;
                        const color = e.target.dataset.color;
                        const code = e.target.dataset.code;

                        dotnetHelper.invokeMethodAsync(method, group, toothno, surface, condition, color, code);
                        popoverInstance.hide();
                    });
                });
            });

            // Hide on outside click
            document.addEventListener('click', function (e) {
                popoverInstance.hide();
            });
        });

    }, 100);
}

function resetPopover(id) {
    var element = '#' + id;
    $('.surface-btn').not(element).popover('hide');
}

function test() {
    alert();
}

function renderPayPalButton(id, subscriptionCode, subscriptionTier, amount) {
    const container = document.getElementById('paypal-button-container');
    $('#paypal-button-container').removeClass('d-none');
    $('#paypal-preloader').addClass('d-none');
    // Clear previous button if already rendered
    if (container) {
        container.innerHTML = ''; // Reset container to avoid duplicate rendering
    }

   paypal.Buttons({
        createOrder: function (data, actions) {
            return actions.order.create({
                purchase_units: [{
                    amount: {
                        value: amount
                    },
                    custom_id: id
                }]
            });
       },
        onApprove: function (data, actions) {
            return actions.order.capture().then(function (details) {
                $('#paypal-button-container').addClass('d-none');
                $('#paypal-preloader').removeClass('d-none');
                // Call Blazor backend to confirm payment
                fetch('api/Paypal/confirm', {
                    method: 'POST',
                    headers: { 'Content-Type': 'application/json' },
                    body: JSON.stringify({
                        data: data,       // raw object, not stringified
                        details: details,  // raw object, not stringified
                        userId: id,
                        subscriptionCode: subscriptionCode,
                        subscriptionTier: subscriptionTier
                    })
                }).then(() => {
                    hideModal('payment-confirmation');
                    $('#paypal-preloader').addClass('d-none');
                    trigger('btn-download');
                });
            });
        }
    }).render('#paypal-button-container');
}

function getAuthToken(dotnetHelper)
{
    const fragment = new URLSearchParams(window.location.hash.substring(1));
    const accessToken = fragment.get("access_token");
    const refreshToken = fragment.get("refresh_token");
    dotnetHelper.invokeMethodAsync('SetSession', accessToken, refreshToken);
}

function countUp() {
    setTimeout(() => {
        // Check if .counter exists and has non-empty text
        if ($('.counter').length && $.trim($('.counter').text()).length > 0) {
            $('.counter').counterUp({
                delay: 50,
                time: 2000
            });
        }
    }, 500);
}

function countUp2(id, value) {
    setTimeout(() => {
        if ($('#' + id).length && $.trim($('#' + id).text()).length > 0) {
            $('#' + id).text(value).counterUp({
                delay: 50,
                time: 2000
            });

            let formatted = value.toLocaleString();
            $('#' + id).text(formatted);
        }
    }, 100);
}





