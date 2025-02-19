import { Component, EventEmitter, Input, Output } from '@angular/core';
import { FormBuilder, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { markAllAsTouched } from '../../util/formUtils';
import { ButtonModule } from 'primeng/button';
import { FloatLabelModule } from 'primeng/floatlabel';
import { InputTextModule } from 'primeng/inputtext';
import { CommonModule } from '@angular/common';
import { PasswordModule } from 'primeng/password';
import { ToastModule } from 'primeng/toast';
import { DialogModule } from 'primeng/dialog';
import { DividerModule } from 'primeng/divider';
import { AuthService } from '../../auth/auth.service';
import { ChangePasswordRequest} from '../../interfaces/model.interfaces';

@Component({
  selector: 'app-update-pass',
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
  templateUrl: './update-pass.component.html',
  styleUrl: './update-pass.component.css'
})
export class UpdatePassComponent {
  @Input() visible : boolean = false;

  @Output() onCloseDialog = new EventEmitter;
  @Output() onToastEmit = new EventEmitter;
  
  title : string = "Actualizar contraseña";

  loading: boolean = false;

  form : FormGroup = this.fb.group({
    currentPassword: ['', [Validators.required]],
    newPassword: ['', [Validators.required]],
    repeatNewPassword: ['', [Validators.required]]
  })

  constructor (
        private readonly authService : AuthService,
        private readonly fb : FormBuilder
  ){}

  sendToken(){
    markAllAsTouched(this.form);

    if(this.isFormValid()){
      let tokenReq : ChangePasswordRequest = this.form.value;
      this.loading = true;
      this.authService.changePassword(tokenReq).subscribe({
        next: () => {
          this.showToast('Su nueva contraseña se ha restaurado correctamente', 'Contraseña restaurada', 'success');
          this.loading = false;
          this.resetAll();
        },
        error: (error) => {
          this.loading = false;
          if (error.message?.includes('Error Status: 4')) {
            this.showToast('Las credenciales son inválidas','Error', 'error');
          } else{
            this.showToast('Ha ocurrido un error. Intente nuevamente o ponganse en contacto con el administrador.', 'Error', 'error');
          }
        }
      })
    }
  }

  hasError(nameField: any){
    let field = this.form.get(nameField); 

    return (field?.dirty || field?.touched) && field?.invalid;
  }

  hasErrorRepeatPass(){
    const newPass = this.form.get("newPassword"); 
    const repeatPass = this.form.get("repeatNewPassword"); 

    const IsDirtyNew = newPass?.dirty || newPass?.touched;
    const IsDirtyRepeat = repeatPass?.dirty || repeatPass?.touched;

    return IsDirtyNew && IsDirtyRepeat && (newPass.value != repeatPass.value);
  }

  isFormValid(){
    return this.form.valid && !this.hasErrorRepeatPass();
  }


  resetAll(){
    this.form.reset();
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
