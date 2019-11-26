import functools
import logging
logger = logging.getLogger('decorator-log')
logger.setLevel(logging.DEBUG)

# create console handler and set level to debug
ch = logging.FileHandler('log.txt')
ch.setLevel(logging.DEBUG)

# create formatter
formatter = logging.Formatter('%(asctime)s - %(name)s - %(levelname)s - %(message)s')

# add formatter to ch
ch.setFormatter(formatter)

# add ch to logger
logger.addHandler(ch)

class LogDecorator(object):
    indent = 0

    def __init__(self):
        self.logger = logging.getLogger('decorator-log')

    def __call__(self, fn):
        @functools.wraps(fn)
        def decorated(*args, **kwargs):
            try:
                self.logger.debug("{0}START {1} - {2} - {3}".format('\t'*LogDecorator.indent, fn.__name__, args, kwargs))
                LogDecorator.indent += 1
                result = fn(*args, **kwargs)
                LogDecorator.indent -= 1
                self.logger.debug("{0}END   {1} - {2}".format('\t'*LogDecorator.indent, fn.__name__, result))
                return result
            except Exception as ex:
                self.logger.debug("Exception {0}".format(ex))
                raise ex
            return result
        return decorated
