import { Component } from '@angular/core';
import { HubConnectionBuilder } from '@microsoft/signalr';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {

  connections: string[] = [];
  constructor() { }

  ngOnInit(): void {
    const connection = new HubConnectionBuilder()
    .withUrl("https://localhost:3000/connections").build();
    
    connection.start()
    .then(() => console.log('Connection started'))
    .catch(err => console.log('Error while starting connection: ' + err))
    
    connection.on("GetConnections", message => {
      this.connections = message;
      console.log(message)
    })
  }
}

