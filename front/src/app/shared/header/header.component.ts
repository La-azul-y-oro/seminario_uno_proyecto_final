import { Component, EventEmitter, Output } from '@angular/core';
import { MenubarModule } from 'primeng/menubar';
import { ButtonModule } from 'primeng/button';
import { UserInfoComponent } from '../../components/user-info/user-info.component';
import { ToastModule } from 'primeng/toast';
import { MessageService } from 'primeng/api';

@Component({
  selector: 'app-header',
  standalone: true,
  imports: [
    ButtonModule,
    MenubarModule,
    ToastModule,
    UserInfoComponent  
    ],
  templateUrl: './header.component.html',
  styleUrl: './header.component.css'
})
export class HeaderComponent {
  @Output() toggleSidebar = new EventEmitter;

  menubarStyle = {
    borderRadius: '0px',
    height: '100%'
  };
  
  constructor(
    private readonly messageService : MessageService
  ) {}

  toggle(){
    this.toggleSidebar.emit()
  }

  showToast(toastData : any){
    this.messageService.add(toastData);
  }
}
