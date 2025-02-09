import { Component, EventEmitter, Output } from '@angular/core';
import { MenubarModule } from 'primeng/menubar';
import { ButtonModule } from 'primeng/button';

@Component({
  selector: 'app-header',
  standalone: true,
  imports: [
    MenubarModule,
    ButtonModule],
  templateUrl: './header.component.html',
  styleUrl: './header.component.css'
})
export class HeaderComponent {
  @Output() toggleSidebar = new EventEmitter;

  menubarStyle = {
    borderRadius: '0px',
    height: '100%'
  };
  
  toggle(){
    this.toggleSidebar.emit()
  }
}
