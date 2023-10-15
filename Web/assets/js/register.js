$(() => {
  $("#register").submit(function (e) {
    e.preventDefault();

    const firstName = $("#firstName").val();
    const lastName = $("#lastName").val();
    const email = $("#email").val();
    const phoneNumber = $("#phoneNumber").val();
    const confirmPassword = $("#confirmPassword").val();
    const password = $("#password").val();

    if (password !== confirmPassword) {
      alert("Password and Password Confirmation are not indentical");
      return;
    }

    const credentials = {
      firstName,
      lastName,
      email,
      phoneNumber,
      password,
    };

    $.ajax({
      url: `${ENV.BASE_URL}/${ENDPOINTS.Basic.Register}`,
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
