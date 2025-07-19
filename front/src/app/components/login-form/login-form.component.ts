import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { ButtonModule } from 'primeng/button';
import { FloatLabelModule } from 'primeng/floatlabel';
import { InputTextModule } from 'primeng/inputtext';
import { Router } from '@angular/router';
import { emailCustomValidator } from '../../util/customValidators';
import { PasswordModule } from 'primeng/password';
import { AuthService } from '../../auth/auth.service';
import { UserLogin } from '../../interfaces/model.interfaces';
import { MessageService } from 'primeng/api';
import { markAllAsTouched } from '../../util/formUtils';
import { ResetPassComponent } from '../reset-pass/reset-pass.component';
import { ToastService } from '../toast/toast-service';

@Component({
  selector: 'app-login-form',
  standalone: true,
  imports: [
    ButtonModule,
    FloatLabelModule,
    InputTextModule,
    CommonModule,
    ReactiveFormsModule,
    ResetPassComponent,
    PasswordModule
  ],
  templateUrl: './login-form.component.html',
  styleUrl: './login-form.component.css'
})
export class LoginFormComponent {
  loading: boolean = false;
  showRecoveryModal: boolean = false;

  constructor(
    private readonly authService: AuthService,
    private readonly fb: FormBuilder,
    private readonly router: Router,
    private readonly messageService: MessageService,
    private readonly toastService : ToastService
  ) { }

  userForm: FormGroup = this.fb.group({
    username: ['', [Validators.required, emailCustomValidator]],
    password: ['', [Validators.required]]
  })


  sendData() {
    markAllAsTouched(this.userForm);

    if (this.userForm.valid) {
      let user: UserLogin = this.userForm.value;
      this.loading = true;
      this.authService.login(user).subscribe({
        next: (token) => {

          const roleAttr = "http://schemas.microsoft.com/ws/2008/06/identity/claims/role";
          const userInfo = this.authService?.userData as any;
          const role = userInfo?.[roleAttr];

          if (role != "CLIENT") {
            this.router.navigate(['/consorcios']);
          } else {
            this.router.navigate(['/mis-unidades']);
          }
        },
        error: (error) => {
          this.loading = false;
          if (error.message?.includes('Error Status: 4')) {
            this.toastService.setErrorMessage('Las credenciales son inválidas.');
          } else {
            this.toastService.setErrorMessage('Ha ocurrido un error. Intente nuevamente o ponganse en contacto con el administrador.');
          }
        }
      })
    }
  }

  hasError(nameField: any) {
    let field = this.userForm.get(nameField);
    return (field?.dirty || field?.touched) && field?.invalid;
  }
} 
