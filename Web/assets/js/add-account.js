checkToken();

function getTypes() {
  $.ajax({
    url: `${ENV.BASE_URL}/${ENDPOINTS.Lookup.GetLookupByParentCode}?code=TY`,
    type: "GET",
    contentType: "application/json; charset=utf-8",
    success: function (response) {
      let HTML = ``;

      $.each(response, function (_, type) {
        const { id, name } = type;

        HTML += /*html*/ `
          <option value="${id}">${name}</option>
        `;
      });

      $("#type").append(HTML);
    },
    error: function (_, _, errorThrown) {
      alert(
        "Sorry, looks like there are some errors detected, please try again later."
      );
      console.error("Error: ", errorThrown);
    },
  });
}

function getCustomers() {
  $.ajax({
    url: `${ENV.BASE_URL}/${ENDPOINTS.Customers}`,
    type: "GET",
    contentType: "application/json; charset=utf-8",
    success: function (response) {
      let HTML = ``;

      $.each(response, function (_, customer) {
        const { customerId, firstName, lastName } = customer;

        HTML += /*html*/ `
          <option value="${customerId}">${firstName} ${lastName}</option>
        `;
      });

      $("#customer").append(HTML);
    },
    error: function (_, _, errorThrown) {
      alert(
        "Sorry, looks like there are some errors detected, please try again later."
      );
      console.error("Error: ", errorThrown);
    },
  });
}

$(() => {
  getCustomers();
  getTypes();

  $("#addAccount").submit(function (e) {
    e.preventDefault();

    const customerId = $("#customer").val();
    const balance = 0;//$("#balance").val();
    const initialCred = $("#initialCred").val();
    const type = $("#type").val();

    // if (password !== confirmPassword) {
    //   alert("Password and Password Confirmation are not indentical");
    //   return;
    // }

    const obj = {
      accountId: 0,
      customerId,
      balance,
      initialCred,
      type,
    };

    $.ajax({
      url: `${ENV.BASE_URL}/${ENDPOINTS.Account.Account}`,
      type: "POST",
      data: JSON.stringify(obj),
      contentType: "application/json; charset=utf-8",
      success: function (response) {
       
          const { message } = response;

          alert(message);
       
      
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
