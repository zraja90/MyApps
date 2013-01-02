var profilePicUpdated = function (src) {
    // Append a timestamp to invalidate cache
    var timestamp = new Date().getTime().toString();
    src += '?t=' + timestamp;
    showMainFormDialog(src);
    $('#Photo').val(src);
};

var showUploadProfilePicDialog = function() {
    $('.imgareaselect-outer').css('background-color', 'black').css('opacity', .5).width(0).height(0);
    initImageAreaSelect();
    $('#mainForm').fadeOut('fast', function () {
        $('#pageTitle').html('Profile Picture');
        $('#photoUploadForm').fadeIn('fast');
    });
};

var showMainFormDialog = function(profilePicSrc) {
    $('#photoUploadForm').fadeOut('fast', function () {
        if (profilePicSrc) {
            $('#profilePhoto').attr('src', profilePicSrc);
        }
            
        $('#pageTitle').html('Edit Profile');
        $('#mainForm').fadeIn('fast', function () {
            $('.imgareaselect-outer').width(0).height(0);  
        });
    });
};

var clearUpload = function () {
    var $preview = $('#preview');
    $preview.attr('src', '/Images/empty.png');
    initImageAreaSelect();
    var $file = $('#File');
    $file.replaceWith($file.clone(true));
    $('#profilePicSubmitButton').addClass('disabled');

    $('.imgareaselect-outer').css('background-color', 'transparent').css('opacity', 0);
};

var initImageAreaSelect = function () {
    var preview = $('#preview').load(function () {
        setPreview();
        var width = $(this).width();
        var height = $(this).height();
        var x1 = 0;
        var x2 = width;
        var y1 = 0;
        var y2 = height;
        var midWidth = width / 2;
        var midHeight = height / 2;

        if (width > 200 && height > 200) {
            x1 = midWidth - 100;
            x2 = midWidth + 100;
            y1 = midHeight - 100;
            y2 = midHeight + 100;
        }
        else if (width > height && width > 200) {
            x1 = midWidth - 100;
            x2 = midWidth + 100;
        } else if (height > width && height > 200) {
            y1 = midHeight - 100;
            y2 = midHeight + 100;
        }

        ias.setOptions({
            x1: x1,
            y1: y1,
            x2: x2,//$(this).width(),
            y2: y2,//$(this).height(),
            maxHeight: 400,
            maxWidth: 400,
            show: true
        });
    });

    //Set the 4 coordinates for the cropping
    var setPreview = function (x, y, w, h) {
        $('#X').val(x || 0);
        $('#Y').val(y || 0);
        $('#Width').val(w || preview[0].naturalWidth);
        $('#Height').val(h || preview[0].naturalHeight);
    };

    //Initialize the image area select plugin
    var ias = preview.imgAreaSelect({
        handles: true,
        instance: true,
        parent: 'body',
        aspectRatio: '1:1',
        onSelectEnd: function (s, e) {
            var scale = preview[0].naturalWidth / preview.width();
            var _f = Math.floor;
            setPreview(_f(scale * e.x1), _f(scale * e.y1), _f(scale * e.width), _f(scale * e.height));
        }
    });

    //Initial state of X, Y, Width and Height is 0 0 1 1
    setPreview(0, 0, 1, 1);
};

var filePreview = function () {
    window.callback = function () {
    };

    $('body').append('<iframe id="preview-iframe" onload="callback();" name="preview-iframe" style="display:none" />');
    var action = $('#uploadProfilePicForm').attr('target', 'preview-iframe').attr('action');
    $('#uploadProfilePicForm').attr('action', '/Common/PreviewImage');

    $('#uploadProfilePicForm').ajaxForm(function (data) {

        $('#preview').attr('src', data);
        $('#profilePicSubmitButton').removeClass('disabled');
        $('#preview-iframe').remove();

        $('#uploadProfilePicForm').ajaxForm(function (ret) {
            var data = $.parseJSON(ret);
            if (data.result === 'success') {
                clearUpload();
                if (profilePicUpdated)
                    profilePicUpdated(data.src);
            } else if (data.msg) {
                alert(data.msg);
            }
        });
    });

    $('#uploadProfilePicForm').submit().attr('action', action + '?returnAsText=1').attr('target', '');
};
    

$(function () {
       
    $('#uploadProfilePicLink').click(function() {
        showUploadProfilePicDialog();
    });

    $('#cancelProfileUploadLink').click(function() {
        showMainFormDialog();
    });
    
    //What happens if the File changes?
    $('#File').change(function (evt) {
        if (evt.target.files === undefined) {
            // workaround for older browsers
            return filePreview();
        }

        var f = evt.target.files[0];
        var reader = new FileReader();

        if (!f.type.match('image.*')) {
            alert("The selected file does not appear to be an image.");
            return;
        }

        $('#profilePicSubmitButton').removeClass('disabled');
        reader.onload = function (e) { $('#preview').attr('src', e.target.result); };
        reader.readAsDataURL(f);
    });
    
    $('#uploadProfilePicForm').ajaxForm(function (data) {
        if (data.result === 'success') {
            clearUpload();
            if (profilePicUpdated)
                profilePicUpdated(data.src);
        } else if (data.msg) {
            alert(data.msg);
        }
    });
    
    $('#cancelProfileUploadLink').click(function () {
        clearUpload();
    });
      
});