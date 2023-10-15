checkToken();

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
  });
}

function getAccounts(customerId) {
  $.ajax({
    url: `${ENV.BASE_URL}/${ENDPOINTS.Account.Account}?customerId=${customerId}`,
    type: "GET",
    contentType: "application/json; charset=utf-8",
    success: function (response) {
      let HTML = ``;

      const { customer, account } = response;
      const { firstName, lastName } = customer;

      $("#firstName").text(firstName);
      $("#lastName").text(lastName);

      $.each(account, function (_, acc) {
        const { accountId, balance } = acc;

        HTML += /*html*/ `
          <tr>
            <td>${balance}</td>
            <td><button type="button" class="btn btn-link" onclick="viewTransaction(
              this,
              ${accountId}
            )">View Transations</button></td>
          </tr>
        `;
      });

      $("#accounts tbody").html(HTML);

      const table = new DataTable("#accounts");
    },
    error: function (_, _, errorThrown) {
      alert(
        "Sorry, looks like there are some errors detected, please try again later."
      );
      console.error("Error: ", errorThrown);
    },
  });
}

function viewTransaction(el, accountId) {
  $(el).text("Loading...");

  $.ajax({
    url: `${ENV.BASE_URL}/${ENDPOINTS.Account.GetTransactions}?accountId=${accountId}`,
    type: "GET",
    contentType: "application/json; charset=utf-8",
    success: function (response) {
      let HTML = ``;

      $.each(response, function (_, transaction) {
        const { createdDate, transactionAmout } = transaction;

        HTML += /*html*/ `
          <tr>
            <td>${transactionAmout}</td>

            <td>${createdDate}</td>
          </tr>
        `;
      });

      $("#transactions tbody").html(HTML);
      $("#transactionsModal").modal("show");

      $(el).text("View Transactions");
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

  $("#viewAccount").submit(function (e) {
    e.preventDefault();
    const customerId = $("#customer").val();

    getAccounts(customerId);
  });
});
