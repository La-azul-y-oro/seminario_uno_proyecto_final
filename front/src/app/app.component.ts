import { Component, ViewChild } from '@angular/core';
import { Router, RouterOutlet } from '@angular/router';
import { MessageService } from 'primeng/api';
import { ButtonModule } from 'primeng/button';
import { CardModule } from 'primeng/card';
import { ToastModule } from 'primeng/toast';
import { HeaderComponent } from './shared/header/header.component';
import { SidebarComponent } from './shared/sidebar/sidebar.component';
import { CommonModule } from '@angular/common';
import { ConfirmDialogComponent } from './components/confirm-dialog/confirm-dialog.component';
import { ConfirmDialogService } from './components/confirm-dialog/confirm-dialog-service';
import { ToastComponent } from './components/toast/toast.component';
import { ToastService } from './components/toast/toast-service';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [
    RouterOutlet,
    ButtonModule,
    CardModule,
    ToastModule,
    HeaderComponent,
    SidebarComponent,
    CommonModule,
    ConfirmDialogComponent,
    ToastComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  @ViewChild(ConfirmDialogComponent) confirmDialogComponent!: ConfirmDialogComponent;
  @ViewChild(ToastComponent) toastComponent!: ToastComponent;

  isSidebarVisible: boolean = false;

  constructor(
    private readonly router: Router,
    private readonly confirmService: ConfirmDialogService,
    private readonly toastService: ToastService
  ) { }


  ngAfterViewInit() {
    this.confirmService.register(this.confirmDialogComponent);
    this.toastService.register(this.toastComponent);
  }

  toggleSidebar() {
    this.isSidebarVisible = !this.isSidebarVisible;
  }

  routeLogin() {
    return this.router.url !== '/login';
  }

}