import { Component, EventEmitter, Output } from '@angular/core';
import { MenuItem } from 'primeng/api';
import { MenubarModule } from 'primeng/menubar';
import { AuthService } from '../../auth/auth.service';
import { Role } from '../../interfaces/model.interfaces';
import { UpdatePassComponent } from '../update-pass/update-pass.component';

@Component({
  selector: 'app-user-info',
  standalone: true,
  imports: [
    MenubarModule,
    UpdatePassComponent
  ],
  templateUrl: './user-info.component.html',
  styleUrl: './user-info.component.css'
})
export class UserInfoComponent {
  @Output() onToastEmit = new EventEmitter;

  visibleUpdate : boolean = false;

  constructor(
    private readonly authService : AuthService
  ) {}
  
  menubarStyle = {
    border: 'none',
    fontSize: '0.85rem'
  };

  items: MenuItem[] = [{
    label: this.getUserInfo(),
    icon: 'pi pi-user',
    items:[
      {
        label: 'Cerrar sesión',
        icon: 'pi pi-power-off',
        command: () => this.authService.logout()
      },
      {
        label: 'Cambiar contraseña',
        icon: 'pi pi-lock',
        command: () => this.openUpdatePass()
      }
    ]
  }];

  private getUserInfo() : string{
    const roleAttr = "http://schemas.microsoft.com/ws/2008/06/identity/claims/role";

    const userInfo = this.authService?.userData as any;
    const name = userInfo?.name;
    const lastName = userInfo?.lastName;
    const role = (userInfo?.[roleAttr]) ? `- ${Role[userInfo[roleAttr] as keyof typeof Role]}` : "";

    return `${name} ${lastName} ${role}`;
  }

  private openUpdatePass(){
    this.visibleUpdate = true;
  }

  showToast(toastData : any){
    this.onToastEmit.emit(toastData);
  }

}
