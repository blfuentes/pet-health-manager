import { TestBed } from "@angular/core/testing";
import { AppComponent } from "./app.component";
import { NO_ERRORS_SCHEMA } from "@angular/core";

describe("AppComponent", () => {
  beforeEach(() => TestBed.configureTestingModule({
    declarations: [AppComponent],
    schemas: [NO_ERRORS_SCHEMA],
  }));

  it("should create the app", () => {
    const fixture = TestBed.createComponent(AppComponent);
    const app = fixture.componentInstance;
    expect(app).toBeTruthy();
  });

  it(`should have as title "Pet health manager"`, () => {
    const fixture = TestBed.createComponent(AppComponent);
    const app = fixture.componentInstance;
    expect(app.title).toEqual("Pet health manager");
  });

  it("should render header", () => {
    const fixture = TestBed.createComponent(AppComponent);
    fixture.detectChanges();
    const compiled = fixture.nativeElement as HTMLElement;
    expect(compiled.querySelector("h1")?.textContent).toContain("Pet health manager");
  });
});
