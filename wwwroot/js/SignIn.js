const UserPassword = document.getElementById('UserPassword');
const UserPasswordConfirm = document.getElementById('UserPasswordConfirm');
const RegisterButton = document.getElementById('RegisterButton');

UserPassword.addEventListener('input', ValidatePassword);
UserPasswordConfirm.addEventListener('input', ValidatePassword);

function ValidatePassword() {
    const UserPasswordVariable = UserPassword.value;
    const UserPasswordConfirmVariable = UserPasswordConfirm.value;

    if ((UserPasswordVariable.length) >= 8 && (UserPasswordVariable === UserPasswordConfirmVariable)) {
        RegisterButton.disabled = false;
        RegisterButton.classList.add("RegisterButtonEnabled");

    } else {
        RegisterButton.disabled = true;
        RegisterButton.classList.remove("RegisterButtonEnabled");
    }
}