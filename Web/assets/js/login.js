$(() => {
  $("#login").submit(function (e) {
    e.preventDefault();

    const login = $("#email").val();
    const password = $("#password").val();

    const credentials = {
      login,
      password,
    };

    $.ajax({
      url: `${ENV.BASE_URL}/${ENDPOINTS.Basic.Login}`,
      type: "POST",
      data: JSON.stringify(credentials),
      contentType: "application/json; charset=utf-8",
      success: function (response) {
        const { userId, accessToken, expiryDate } = response;

        localStorage.setItem("accessToken", accessToken);
        localStorage.setItem("userId", userId);
        localStorage.setItem("expiryDate", expiryDate);

        window.location.href = "add-account.html";
      },
      error: function (_, _, errorThrown) {
        alert(
          "Sorry, looks like there are some errors detected, please try again later."
        );
        console.error("Error: ", errorThrown);
      },
    });
  });
});
