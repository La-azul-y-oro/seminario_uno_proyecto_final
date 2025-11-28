import { CommonModule } from '@angular/common';
import { Component, EventEmitter, Input, Output } from '@angular/core';
import { ButtonModule } from 'primeng/button';
import { TooltipModule } from 'primeng/tooltip';

@Component({
  selector: 'app-action-buttons',
  standalone: true,
  imports: [
    CommonModule,
    ButtonModule,
    TooltipModule
  ],
  templateUrl: './action-buttons.component.html',
  styleUrl: './action-buttons.component.css'
})
export class ActionButtonsComponent {
  @Input() buttons?: ActionButtonConfig[];
  @Input() data!: any;
  @Output() buttonClick = new EventEmitter<{ action: Function, data: any }>();

  @Input() actionButtonStyle = {
    height: '30px',
    width: '30px', 
    padding: '0px',
    marginLeft: '5px',
    marginRight: '5px'
  };

  isButtonHidden(button: ActionButtonConfig): boolean {
    if (typeof button.hidden === 'function') {
      return button.hidden(this.data);
    }
    return button.hidden || false;
  }

  onClick(action: Function, data: any) {
    action(data);
  }
}

export interface ActionButtonConfig {
  icon: string;
  tooltip: string;
  severity: Severity;
  action: Function;
  isDisabled?: boolean;
  hidden?: boolean | ((row: any) => boolean);
  data?: any;
}


type Severity = "success" | "info" | "warning" | "danger" | "help" | "primary" | "secondary" | "contrast";