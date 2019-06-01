import { TestBed } from '@angular/core/testing';

import { ClassService } from './class.service';

describe('ClassService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: ClassService = TestBed.get(ClassService);
    expect(service).toBeTruthy();
  });
});
