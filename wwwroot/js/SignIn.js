const Password_User = document.getElementById('Password_User');
const Password_UserConfirm = document.getElementById('Password_UserConfirm');
const RegisterButton = document.getElementById('RegisterButton');

Password_User.addEventListener('input', ValidatePassword);
Password_UserConfirm.addEventListener('input', ValidatePassword);

function ValidatePassword() {
    const Password_UserVariable = Password_User.value;
    const Password_UserConfirmVariable = Password_UserConfirm.value;

    if ((Password_UserVariable.length) >= 8 && (Password_UserVariable === Password_UserConfirmVariable)) {
        RegisterButton.disabled = false;
        RegisterButton.classList.add("RegisterButtonEnabled");

    } else {
        RegisterButton.disabled = true;
        RegisterButton.classList.remove("RegisterButtonEnabled");
    }
}