var Authentication = {
    loginForm: {},

    login: function () {
        loginForm = $.confirm({
            title: "Login",
            draggable: false,
            content: 'url:../pages/_LoginForm.html',
            buttons: {
                formSubmit: {
                    text: 'Submit',
                    btnClass: 'btn-orange',
                    action: function () {
                        var invalid = false;
                        $(".required").each(function () {
                            if ($(this).val() == "") {
                                $(this).addClass("red-highlight");
                                invalid = true;
                            }
                            else {
                                $(this).removeClass("red-highlight");
                            }
                        });

                        if (invalid) {
                            return false;
                        }

                        var user = {
                            email: this.$content.find('#email-input').val(),
                            password: this.$content.find('#password-input').val()
                        };

                        Authentication.authenticateUser(user);

                        return true;
                    }
                },
                cancel: function () {
                    
                },
            }
        });
    },

    authenticateUser: function (user) {
        $.ajax({
            type: 'POST',
            url: 'Authentication/Login',
            data: user,
            success: function (response) {
                location.reload();
            },
            error: function (response) {
                //$.notify("Wrong email or password. Please try again", "error");
            }
        });
    },

    register: function () {
        loginForm.close();
        $.confirm({
            title: "Register",
            draggable: true,
            content: 'url:../pages/_RegisterForm.html',
            buttons: {
                formSubmit: {
                    text: 'Submit',
                    btnClass: 'btn-orange',
                    action: function () {
                        var invalid = false;
                        $(".required").each(function () {
                            if ($(this).val() == "") {
                                $(this).addClass("red-highlight");
                                invalid = true;
                            }
                            else {
                                $(this).removeClass("red-highlight");
                            }
                        });

                        if (invalid) {
                            return false;
                        }

                        var user = {
                            firstName: this.$content.find('#first-name-input').val(),
                            lastName: this.$content.find('#last-name-input').val(),
                            email: this.$content.find('#email-input').val(),
                            password: this.$content.find('#password-input').val()
                        };

                        $.ajax({
                            type: 'POST',
                            url: 'Authentication/Register',
                            data: user,
                            success: function (response) {
                                location.reload();
                            },
                            error: function () {
                                //$.notify("Something went wrong please try again later", "error");
                            }
                        });

                        return true;
                    }
                },
                cancel: function () {

                },
            }
        });
    }
}
