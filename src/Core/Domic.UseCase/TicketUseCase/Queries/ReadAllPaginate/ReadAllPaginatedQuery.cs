﻿using Domic.Core.UseCase.Contracts.Abstracts;
using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.UseCase.TicketUseCase.DTOs;

namespace Domic.UseCase.TicketUseCase.Queries.ReadAllPaginate;

public class ReadAllPaginatedQuery : PaginatedQuery, IQuery<List<TicketDto>>;