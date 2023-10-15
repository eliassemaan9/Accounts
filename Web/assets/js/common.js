const ENV = {
  BASE_URL: "https://localhost:44331/api",
};

const ENDPOINTS = {
  Basic: {
    Login: "basic/login",
    Register: "basic/register",
  },
  Account: {
    Account: "account",
    GetTransactions: "account/getTransactions",
  },
  Lookup: {
    GetLookupByParentCode: "lookups/getLookupByParentCode",
  },
  Customers: "customers",
};

$.ajaxSetup({
  headers: {
    Authorization: `Bearer ${getToken()}`,
  },
});

function checkToken() {
  if (!getToken()) window.location.href = "index.html";

  if (!getTokenExpiryDate()) window.location.href = "index.html";

  if (getTokenExpiryDate() < new Date().getTime())
    window.location.href = "index.html";
}

function getToken() {
  return localStorage.getItem("accessToken");
}

function getTokenExpiryDate() {
  const expiryDate = localStorage.getItem("expiryDate");

  if (expiryDate) {
    const expiryTime = new Date(expiryDate).getTime();

    return expiryTime;
  }

  return null;
}

function logout() {
  localStorage.clear();
  window.location.href = "index.html";
}
