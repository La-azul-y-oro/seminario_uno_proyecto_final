import { Component, EventEmitter, Input, Output } from '@angular/core';
import { FormBuilder, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { markAllAsTouched } from '../../util/formUtils';
import { emailCustomValidator } from '../../util/customValidators';
import { ButtonModule } from 'primeng/button';
import { FloatLabelModule } from 'primeng/floatlabel';
import { InputTextModule } from 'primeng/inputtext';
import { CommonModule } from '@angular/common';
import { PasswordModule } from 'primeng/password';
import { DialogModule } from 'primeng/dialog';
import { DividerModule } from 'primeng/divider';
import { AuthService } from '../../auth/auth.service';
import { ForgotPasswordRequest, ResetPasswordRequest } from '../../interfaces/model.interfaces';
import { ToastService } from '../toast/toast-service';

@Component({
  selector: 'app-reset-pass',
  standalone: true,
  imports: [
    ButtonModule,
    CommonModule,
    DialogModule,
    DividerModule,
    FloatLabelModule,
    FormsModule,
    InputTextModule,
    PasswordModule,
    ReactiveFormsModule
  ],
  templateUrl: './reset-pass.component.html',
  styleUrl: './reset-pass.component.css'
})
export class ResetPassComponent {
  @Input() visible : boolean = false;

  @Output() onCloseDialog = new EventEmitter;
  
  title : string = "Recupero de contraseña";

  isTokenForm : boolean = false;
  isEmailForm : boolean = false; 
  loading: boolean = false;

  tokenForm : FormGroup = this.fb.group({
    token: ['', [Validators.required]],
    newPassword: ['', [Validators.required]]
  })

  sendEmailForm : FormGroup = this.fb.group({
    email: ['', [Validators.required, emailCustomValidator]]
  })

  constructor (
        private readonly authService : AuthService,
        private readonly fb : FormBuilder,
        private readonly toastService : ToastService
  ){}

  sendToken(){
    markAllAsTouched(this.tokenForm);

    if(this.tokenForm.valid){
      let tokenReq : ResetPasswordRequest = this.tokenForm.value;
      this.loading = true;
      this.authService.resetPassword(tokenReq).subscribe({
        next: () => {
          this.toastService.setSuccessMessage('Su contraseña se ha seteado correctamente');
          this.loading = false;
          this.resetAll();
        },
        error: (error) => {
          this.loading = false;
          console.error(error);
          this.toastService.setErrorMessage('Ha ocurrido un error. Intente nuevamente o ponganse en contacto con el administrador.');
        }
      })
    }
  }

  sendEmail(){
    markAllAsTouched(this.sendEmailForm);

    if(this.sendEmailForm.valid){
      let forgotReq : ForgotPasswordRequest = this.sendEmailForm.value;
      this.loading = true;
      this.authService.forgotPassword(forgotReq).subscribe({
        next: () => {
          this.toastService.setSuccessMessage('Si el mail proporcionado existe estará recibiendo en el mismo el token para restaurar la contraseña.');
          this.loading = false;
          this.resetAll();
        },
        error: (error) => {
          this.loading = false;
          console.error(error);
          this.toastService.setErrorMessage('Ha ocurrido un error. Intente nuevamente o ponganse en contacto con el administrador.');
        }
      })
    }
  }

  hasError(nameField: any, form: FormGroup){
    let field = form.get(nameField); 
    return (field?.dirty || field?.touched) && field?.invalid;
  }

  resetAll(){
    this.tokenForm.reset();
    this.sendEmailForm.reset();
    this.isTokenForm = false;
    this.isEmailForm = false;
    this.onCloseDialog.emit();
  }

}
