import { Component, ChangeDetectionStrategy } from "@angular/core";
import { MessageService } from "./services/message.service";

@Component({
    selector: "app-messages",
    templateUrl: "./messages.component.html",
    styleUrls: ["./messages.component.scss"],
    changeDetection: ChangeDetectionStrategy.Eager,
    standalone: false
})
export class MessagesComponent {
  constructor(public messageService: MessageService) { }
}
