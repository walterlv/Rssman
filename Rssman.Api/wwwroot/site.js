const uri = 'api/rss';
let rssfeeds = null;
function getCount(data) {
    const el = $('#counter');
    if (data) {
        el.text(data + ' 个 RSS 项');
    } else {
        el.html('还没有订阅 RSS');
    }
}

$(document).ready(function () {
    getData();
});

function getData() {
    $.ajax({
        type: 'GET',
        url: uri,
        success: function (data) {
            $('#rssFeeds').empty();
            getCount(data.length);
            $.each(data, function (key, item) {
                $('<tr>' +
                    '<td>' + item.name + '</td>' +
                    '<td>' + item.feedUrl + '</td>' +
                    '<td>' + item.siteUrl + '</td>' +
                    '<td><button onclick="editItem(' + item.id + ')">Edit</button></td>' +
                    '<td><button onclick="deleteItem(' + item.id + ')">Delete</button></td>' +
                    '</tr>').appendTo($('#rssFeeds'));
            });

            rssFeeds = data;
        }
    });
}

function addItem() {
    const item = {
        'name': $('#add-name').val(),
        'feedUrl': $('#add-feed-url').val(),
        'siteUrl': $('#add-site-url').val()
    };

    $.ajax({
        type: 'POST',
        accepts: 'application/json',
        url: uri,
        contentType: 'application/json',
        data: JSON.stringify(item),
        error: function (jqXHR, textStatus, errorThrown) {
            alert('here');
        },
        success: function (result) {
            getData();
            $('#add-name').val('');
        }
    });
}

function deleteItem(id) {
    $.ajax({
        url: uri + '/' + id,
        type: 'DELETE',
        success: function (result) {
            getData();
        }
    });
}

function editItem(id) {
    $.each(rssFeeds, function (key, item) {
        if (item.id === id) {
            $('#edit-name').val(item.name);
            $('#edit-feed-url').val(item.feedUrl);
            $('#edit-site-url').val(item.siteUrl);
        }
    });
    $('#spoiler').css({ 'display': 'block' });
}

$('.my-form').on('submit', function () {
    const item = {
        'name': $('#edit-name').val(),
        'feedUrl': $('#edit-feed-url').val(),
        'siteUrl': $('#edit-site-url').val(),
        'id': $('#edit-id').val()
    };

    $.ajax({
        url: uri + '/' + $('#edit-id').val(),
        type: 'PUT',
        accepts: 'application/json',
        contentType: 'application/json',
        data: JSON.stringify(item),
        success: function (result) {
            getData();
        }
    });

    closeInput();
    return false;
});

function closeInput() {
    $('#spoiler').css({ 'display': 'none' });
}