import { Component, EventEmitter, Input, Output } from '@angular/core';
import { FormBuilder, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { markAllAsTouched } from '../../util/formUtils';
import { emailCustomValidator } from '../../util/customValidators';
import { ButtonModule } from 'primeng/button';
import { FloatLabelModule } from 'primeng/floatlabel';
import { InputTextModule } from 'primeng/inputtext';
import { CommonModule } from '@angular/common';
import { PasswordModule } from 'primeng/password';
import { ToastModule } from 'primeng/toast';
import { DialogModule } from 'primeng/dialog';
import { DividerModule } from 'primeng/divider';
import { AuthService } from '../../auth/auth.service';
import { ForgotPasswordRequest, ResetPasswordRequest } from '../../interfaces/model.interfaces';

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
    ReactiveFormsModule,
    ToastModule
  ],
  templateUrl: './reset-pass.component.html',
  styleUrl: './reset-pass.component.css'
})
export class ResetPassComponent {
  @Input() visible : boolean = false;

  @Output() onCloseDialog = new EventEmitter;
  @Output() onToastEmit = new EventEmitter;
  
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
        private readonly fb : FormBuilder
  ){}

  sendToken(){
    markAllAsTouched(this.tokenForm);

    if(this.tokenForm.valid){
      let tokenReq : ResetPasswordRequest = this.tokenForm.value;
      this.loading = true;
      this.authService.resetPassword(tokenReq).subscribe({
        next: () => {
          this.showToast('Su nueva contraseña se ha restaurado correctamente', 'Contraseña restaurada', 'success');
          this.loading = false;
          this.resetAll();
        },
        error: (error) => {
          this.loading = false;
          console.error(error);
          this.showToast('Ha ocurrido un error. Intente nuevamente o ponganse en contacto con el administrador.', 'Error', 'error');
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
          this.showToast('Si el mail proporcionado existe estará recibiendo en el mismo el token para restaurar la contraseña.', 'Token enviado', 'success');
          this.loading = false;
          this.resetAll();
        },
        error: (error) => {
          this.loading = false;
          console.error(error);
          this.showToast('Ha ocurrido un error. Intente nuevamente o ponganse en contacto con el administrador.', 'Error','error');
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

  showToast(message : string, summary : string, severity: string) {
    const toastData = {
      severity: severity,
      summary: summary,
      detail: message,
      life: 4000
    };
    this.onToastEmit.emit(toastData);
  }

}
